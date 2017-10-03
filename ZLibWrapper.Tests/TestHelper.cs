﻿using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.Cryptography;

namespace ZLibWrapper.Tests
{
    [TestClass]
    public class TestHelper
    {
        public static string BaseDir { get; private set; }

        [AssemblyInitialize]
        public static void Init(TestContext ctx)
        {
            string dllPath;
            if (IntPtr.Size == 8)
                dllPath = Path.Combine("x64", "zlibwapi.dll");
            else
                dllPath = Path.Combine("x86", "zlibwapi.dll");
            ZLibNative.AssemblyInit(dllPath);

            BaseDir = Path.Combine("..", "..", "Samples");
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
