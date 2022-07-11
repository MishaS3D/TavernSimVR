using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class SwapLights : MonoBehaviour
{
    public List<AssetReferenceT<AlternativeLightingData>> lightStates;
    private int currentIndex;

    private AsyncOperationHandle<AlternativeLightingData> currentHandle;
    
    [ContextMenu("Cycle")]
    public void Cycle()
    {
        currentIndex++;
        if (currentIndex >= lightStates.Count)
        {
            currentIndex = 0;
        }

        Select(currentIndex);
    }

    public async void Select(int index)
    {
        if(currentHandle.IsValid())
            Addressables.Release(currentHandle);
        currentHandle = Addressables.LoadAssetAsync<AlternativeLightingData>(lightStates[currentIndex]);
        var data = await currentHandle.Task;
        Setup(data);
    }

    public void Setup(AlternativeLightingData data)
    {
        //Make new lightmapData that we can edit at the start of the game
        var LightMapsData = new LightmapData[data.l_Light.Length];

        //Add all our lightmaps textures to the temps LightmapData
        for (int i = 0; i < data.l_Light.Length; i++)
        {
            LightMapsData[i] = new LightmapData();
            LightMapsData[i].lightmapColor = data.l_Light[i];

            if (data.l_Dir.Length >= i)
            {
                LightMapsData[i].lightmapDir = data.l_Dir[i];
            }
        }

        //Replace the starting lightmap data with our new edited one
        LightmapSettings.lightmaps = LightMapsData;
    }
}
