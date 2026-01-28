using Microsoft.Extensions.Options;
using System;
using System.Text.Json;

namespace tesAsprak.Models
{
    public class Buku
    {
        private int id { get; set; }
        private string judul { get; set; }
        private string penulis { get; set; }
        private int tahunTerbit { get; set; }
        private bool tersedia { get; set; }

        public Buku(int id, string judul, string penulis, int tahunTerbit, bool tersedia)
        {
            this.id = id;
            this.judul = judul;
            this.penulis = penulis;
            this.tahunTerbit = tahunTerbit;
            this.tersedia = tersedia;
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }   

        public string Judul
        {
            get { return judul; }
            set { judul = value; }
        }

        public string Penulis
        {
            get { return penulis; }
            set { penulis = value; }
        }

        public int TahunTerbit
        {
            get { return tahunTerbit; }
            set { tahunTerbit = value; }
        }

        public bool Tersedia
        {
            get { return tersedia; }
            set { tersedia = value; }
        }

        public static void ReadJSON(string fileName)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            string jsonString = File.ReadAllText(filePath);

            Buku Data = JsonSerializer.Deserialize<Buku>(jsonString);
        }

        public static void AddJSON(Buku buku, string filePath)
        {
            string jsonString = JsonSerializer.Serialize(buku);
            File.WriteAllText(filePath, jsonString);
        }
    }
}