﻿/*
    Derived from zlib header files (zlib license)
    Copyright (C) 1995-2017 Jean-loup Gailly and Mark Adler

    C# Wrapper based on zlibnet v1.3.3 (https://zlibnet.codeplex.com/)
    Copyright (C) @hardon (https://www.codeplex.com/site/users/view/hardon)
    Copyright (C) 2017-2018 Hajin Jang

    zlib license

    This software is provided 'as-is', without any express or implied
    warranty.  In no event will the authors be held liable for any damages
    arising from the use of this software.

    Permission is granted to anyone to use this software for any purpose,
    including commercial applications, and to alter it and redistribute it
    freely, subject to the following restrictions:

    1. The origin of this software must not be misrepresented; you must not
       claim that you wrote the original software. If you use this software
       in a product, an acknowledgment in the product documentation would be
       appreciated but is not required.
    2. Altered source versions must be plainly marked as such, and must not be
       misrepresented as being the original software.
    3. This notice may not be removed or altered from any source distribution.
*/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Security.Cryptography;

namespace Joveler.ZLib.Tests
{
    [TestClass]
    public class TestSetup
    {
        public static string SampleDir { get; private set; }

        [AssemblyInitialize]
        public static void Init(TestContext ctx)
        {
            string dllPath;
            if (IntPtr.Size == 8)
                dllPath = Path.Combine("x64", "zlibwapi.dll");
            else
                dllPath = Path.Combine("x86", "zlibwapi.dll");
            ZLibInit.GlobalInit(dllPath);

            SampleDir = Path.Combine("..", "..", "Samples");
        }

        [AssemblyCleanup]
        public static void Cleanup()
        {
            ZLibInit.GlobalCleanup();
        }

        public static byte[] SHA256Digest(Stream stream)
        {
            HashAlgorithm hash = SHA256.Create();
            return hash.ComputeHash(stream);
        }

        public static byte[] SHA256Digest(byte[] input)
        {
            HashAlgorithm hash = SHA256.Create();
            return hash.ComputeHash(input);
        }
    }
}
