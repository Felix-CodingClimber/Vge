﻿using System;

namespace Vge.NBT
{
    /// <summary>
    /// Тэг массива байтов для NBT
    /// </summary>
    public class TagByteArray : NBTBase
    {
        private byte[] data = new byte[0];

        public TagByteArray() { }
        public TagByteArray(byte[] data) => this.data = data;

        public override void Write(NBTStream output)
        {
            output.WriteInt(data.Length);
            output.Write(data, 0, data.Length);
        }
        public override void Read(NBTStream input)
        {
            data = new byte[input.ReadInt()];
            input.Read(data, 0, data.Length);
        }

        public override NBTBase Copy()
        {
            byte[] ar = new byte[data.Length];
            Array.Copy(data, 0, ar, 0, data.Length);
            return new TagByteArray(ar);
        }
        public override byte GetId() => 7;

        public override string ToString() => "[" + data.Length + " bytes]";

        public override bool Equals(object value) 
            => base.Equals(value) ? Equals(data, ((TagByteArray)value).data) : false;

        public override int GetHashCode() => base.GetHashCode() ^ data.GetHashCode();

        public byte[] GetByteArray() => data;
    }
}
