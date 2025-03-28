using UnityEngine;

public class SimpleSkyboxSwitcher : MonoBehaviour
{
    [SerializeField] private Material skybox1; 
    [SerializeField] private Material skybox2; 

    private bool isUsingSkybox1 = true; 

    
    public void ToggleSkybox()
    {
        if (isUsingSkybox1)
        {
            RenderSettings.skybox = skybox2;
        }
        else
        {
            RenderSettings.skybox = skybox1;
        }

        isUsingSkybox1 = !isUsingSkybox1; 
        DynamicGI.UpdateEnvironment(); 
    }
}
