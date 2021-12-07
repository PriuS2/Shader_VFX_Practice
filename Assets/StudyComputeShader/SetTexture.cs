using System;
using UnityEngine;

namespace StudyComputeShader
{
    public class SetTexture : MonoBehaviour
    {
        private CSTest _csTest;
        private MeshRenderer _mr;

        private int MainTexture;

        private void Start()
        {
            _csTest = GetComponent<CSTest>();
            _mr = GetComponent<MeshRenderer>();

            MainTexture = Shader.PropertyToID("_BaseMap");
            
            //_mr.sharedMaterial.SetTexture(MainTexture, _csTest.RenderTexture);
        }

        private void Update()
        {
            _mr.sharedMaterial.SetTexture(MainTexture, _csTest.RenderTexture);
        }
    }//Class
}//nameSpace