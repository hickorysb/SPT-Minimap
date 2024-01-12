using System;
using System.Reflection;
using Comfort.Common;
using EFT;
using Aki.Reflection.Patching;
using StayInTarkov.Coop;
using UnityEngine;

namespace CactusPie.MapLocation.Patches
{
    public sealed class PatchCoopInOutdatedVersion : ModulePatch
    {
        protected override MethodBase GetTargetMethod()
        {
            return typeof(CoopGame).GetMethod(nameof(CoopGame.vmethod_4));
        }

        [PatchPostfix]
        public static void Postfix()
        {
            if (Type.GetType("StayInTarkov.Coop.TarkovApplication_LocalGameCreator_Patch") == null)
            {
                Singleton<GameWorld>.Instance.OnGameStarted();
            }
        }
    }
}