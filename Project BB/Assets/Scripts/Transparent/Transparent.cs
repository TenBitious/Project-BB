using UnityEngine;
using System.Collections;

public class Transparent : MonoBehaviour {
    Renderer[] m_Child_Renderers;

    public float alphaRate;

	// Use this for initialization
	void Start () {
        m_Child_Renderers = GetComponentsInChildren<Renderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    //Test
        //
        if (Input.GetKeyDown(KeyCode.E))
        {
            EnableTransparent();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            DisableTransparent();
        }
        

	}

    public void EnableTransparent()
    {
        foreach(Renderer t_renderer in m_Child_Renderers)
        {
            Material t_Mat = t_renderer.material;
            SetRenderingModeTransparent(t_Mat);
            Color t_color = t_renderer.material.color;
            t_color.a = alphaRate;

            t_Mat.color = t_color;
            t_renderer.material = t_Mat;
            Debug.Log("Alpha rate: " + t_renderer.material.color.a + " Hec Color: ");
        }
    }

    public void DisableTransparent()
    {
        foreach (Renderer t_renderer in m_Child_Renderers)
        {
            SetRenderingModeOpaque(t_renderer.material);
            Color t_color = t_renderer.material.color;
            t_color.a = 255;
            t_renderer.material.color = t_color;
        }
    }

    void SetRenderingModeTransparent(Material c_Material)
    {
        c_Material.SetFloat("_Mode", 3);
        c_Material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
        c_Material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        c_Material.SetInt("_ZWrite", 0);
        c_Material.DisableKeyword("_ALPHATEST_ON");
        c_Material.DisableKeyword("_ALPHABLEND_ON");
        c_Material.EnableKeyword("_ALPHAPREMULTIPLY_ON");
        c_Material.renderQueue = 3000;
        
        
    }

    void SetRenderingModeOpaque(Material c_Material)
    {
        c_Material.SetFloat("_Mode", 1);
        c_Material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
        c_Material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
        c_Material.SetInt("_ZWrite", 1);
        c_Material.DisableKeyword("_ALPHATEST_ON");
        c_Material.DisableKeyword("_ALPHABLEND_ON");
        c_Material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        c_Material.renderQueue = -1;
    }
}
