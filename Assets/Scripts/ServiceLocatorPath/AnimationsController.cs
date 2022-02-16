using System.Collections.Generic;
using UnityEngine;

namespace ServiceLocatorPath
{
    public class AnimationsController : IAnimations
    {
        private readonly List<AnimationClip> _clips;
        private int index;

        public AnimationsController(List<AnimationClip> clips)
        {
            _clips = clips;
        }

        public string GetIdle()
        {
            return _clips[index].name;
        }

        public string NextAnim()
        {
            index++;
            if (index > _clips.Count - 1)
            {
                index = 0;
            }
            return GetIdle();
        }

        public string PreviousAnim()
        {
            index--;
            if (index < 0)
            {
                index = _clips.Count - 1;
            }
            return GetIdle();
        }
    }
}