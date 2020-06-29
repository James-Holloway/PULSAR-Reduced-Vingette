using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Reduced_Vingette
{
    [HarmonyPatch(typeof(PLPostProcessVignette), "")]
    [HarmonyPatch("OnRenderImage")]
    class VignetteOverride
    {
        static void Prefix(PLPostProcessVignette __instance, out float __state)
        {
            float multiplier = 0.5f;
            __instance.VignetteAmount *= multiplier;
            __instance.VignetteSize   *= multiplier;
            __instance.ExposureBoost  *= multiplier;
            __state = multiplier;
        }
        static void Postfix(PLPostProcessVignette __instance, float __state)
        {
            __instance.VignetteAmount *= 1 / __state;
            __instance.VignetteSize   *= 1 / __state;
            __instance.ExposureBoost  *= 1 / __state;
        }
    }
}
