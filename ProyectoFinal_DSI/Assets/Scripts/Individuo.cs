using System;
using UnityEngine;

namespace Final_namespace
{

    [Serializable]
    public class Individuo
    {
        public event Action Cambio;


        [SerializeField] private Sprite image;

        public Sprite Image
        {

            get { return image; }
            set
            {
                if (value != image)
                {
                    image = value;
                    Cambio?.Invoke();
                }
            }

        }


        public Individuo(Sprite image)
        {
            
            this.image = image;
        }

    }

}