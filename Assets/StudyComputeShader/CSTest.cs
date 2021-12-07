using System;
using UnityEngine;

namespace StudyComputeShader
{
    public class CSTest : MonoBehaviour
    {

        #region Variables&Properties

        [SerializeField] private ComputeShader _computeShader;
        [SerializeField] private RenderTexture _renderTexture;

        public RenderTexture RenderTexture => _renderTexture;
        private int _resolution = 1024;

        private int _kernelID;


        private struct CSParam
        {
            public const string KERNEL = "CSMain";
            public const string RESULT = "Result";
            public const string TIME = "_time";
            public const int THREAD_NUMBER_X = 8;
            public const int THREAD_NUMBER_Y = 8;
            public const int THREAD_NUMBER_Z = 1;
        }

        #endregion

        #region MonoBehaviour

        private void Awake()
        {
            Initialize();
            //DispatchComputeShader();
        }

        private void Update()
        {
            DispatchComputeShader();
        }

        #endregion


        #region computeShader

        private void Initialize()
        {
            _kernelID = _computeShader.FindKernel(CSParam.KERNEL);
            _renderTexture = new RenderTexture(_resolution, _resolution, 24);
            _renderTexture.enableRandomWrite = true;
            _renderTexture.Create();
        }

        private void DispatchComputeShader()
        {
            _computeShader.SetTexture(_kernelID, CSParam.RESULT, _renderTexture);
            _computeShader.SetFloat(CSParam.TIME, Time.time);
            
            _computeShader.Dispatch(_kernelID,
                _resolution / CSParam.THREAD_NUMBER_X,
                _resolution / CSParam.THREAD_NUMBER_Y,
                _resolution / CSParam.THREAD_NUMBER_X);
        }
        #endregion
    }
}