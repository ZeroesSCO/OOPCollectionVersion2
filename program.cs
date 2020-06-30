using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPCollectionVersion2{
    abstract class Karyawan{
        public string NIK { get; set; }
        public string Nama { get; set; }
        public string tipekaryawan { get; set; }
        public abstract double Gaji();
    }

    class Karyawantetap : Karyawan{
        public double GajiBulanan { get; set; }
        public override double Gaji() => GajiBulanan;
    }

    class Karyawanharian : Karyawan{
        public double UpahPerJam { get; set; }
        public double JumlahJamKerja { get; set; }
        public override double Gaji() => UpahPerJam * JumlahJamKerja;
    }

    class Sales : Karyawan{
        public double JumlahPenjualan { get; set; }
        public double Komisi { get; set; }
        public override double Gaji() => JumlahPenjualan * Komisi;
    }

    class Program{
        static void Main(string[] args){
            Console.Title = "Tugas Lab 9 -  OOPCollection #2";
            List<Karyawan> listKaryawan = new List<Karyawan>();

            void addkar_tetap(string tipekar, string nik, string nama, int gajibulanan){
                listKaryawan.Add(new Karyawantetap { NIK = nik, Nama = nama, GajiBulanan = gajibulanan, tipekaryawan = tipekar });
            }

            void addkar_harian(string tipekar, string nik, string nama, int upahperjam, int jumlahjamkerja){
                listKaryawan.Add(new Karyawanharian { NIK = nik, Nama = nama, UpahPerJam = upahperjam, JumlahJamKerja = jumlahjamkerja, tipekaryawan = tipekar });
            }

            void add_sales(string tipekar, string nik, string nama, int jumlahjual, int komisi){

                listKaryawan.Add(new Sales { NIK = nik, Nama = nama, JumlahPenjualan = jumlahjual, Komisi = komisi, tipekaryawan = tipekar });
            }

            void show(){
                Console.WriteLine("\n");
                int no = 1;

                foreach (Karyawan karyawan in listKaryawan){
                    Console.WriteLine("Tampil Data\n");
                    Console.WriteLine("{0}. Data {0}\nNIK\t: {1}\nNama\t: {2} \nGaji\t: {3:N0}\nTipe\t: {4}\n", no, karyawan.NIK, karyawan.Nama, karyawan.Gaji(), karyawan.tipekaryawan);
                    no++;
                }
            }

            void hapus_karyawan(){
                int no = 1;
                int jumlahkar = 0;

                foreach (Karyawan karyawan in listKaryawan){
                    Console.WriteLine("{0}. Nik: {1}", no, karyawan.Nik);
                    no++;
                    jumlahkar += 1;
                }

                Console.Write("Pilih Data Yang Ingin Dihapus [1-");
                Console.Write(jumlahkar);
                Console.Write("] : ");

                int index_nik = int.Parse(Console.ReadLine());
                index_nik = index_nik - 1;

                listKaryawan.RemoveAt(index_nik);
                Console.WriteLine("Data Karyawan Berhasil Dihapus ");
                Console.WriteLine("\nTekan Enter Untuk Kembali ke Menu");
            }


            bool keluar = false;
            while (keluar == false){
                Console.WriteLine("<< -- Pilih menu Aplikasi -- >>\n\n");
                Console.WriteLine(">> 1. \tTambah Data");
                Console.WriteLine(">> 2. \tHapus Data");
                Console.WriteLine(">> 3. \tTampil Data");
                Console.WriteLine(">> 4. \tKeluar");
                Console.WriteLine("\n\n");
                Console.Write(">> Ketik [1-4] : ");
                int menu = int.Parse(Console.ReadLine());

                if (menu == 1){
                    Console.Clear();
                    Console.WriteLine("<< -- Pilih Tipe Karyawan -- >>\n\n");
                    Console.WriteLine(">>1. \tKaryawan Tetap");
                    Console.WriteLine(">>2. \tKaryawan Harian");
                    Console.WriteLine(">>3. \tSales");
                    Console.WriteLine("\n\n");
                    Console.Write(">> Ketik [1-3] : ");

                    int tipe = int.Parse(Console.ReadLine());

                    if (tipe == 1){
                        Console.Clear();
                        Console.WriteLine("Isi data Karyawan Tetap\n");
                        Console.Write("NIK\t: ");
                        string nik = Console.ReadLine();
                        Console.Write("Nama\t: ");
                        string nama = Console.ReadLine();
                        Console.Write("Gaji Bulanan\t: ");
                        int gajibulanan = int.Parse(Console.ReadLine());
                        string tipekar = "Karyawan Tetap";
                        Console.WriteLine("\n");
                        addkar_tetap(tipekar, nik, nama, gajibulanan);
                    }
                    if (tipe == 2){
                        Console.Clear();
                        Console.WriteLine("Isi data Karyawan Harian\n");
                        Console.Write("NIK\t: ");
                        string nik = Console.ReadLine();
                        Console.Write("Nama\t: ");
                        string nama = Console.ReadLine();
                        Console.Write("Upah Perjam\t: ");
                        int upahperjam = int.Parse(Console.ReadLine());
                        Console.Write("Jumlah Jam Kerja\t: ");
                        int jamkerja = int.Parse(Console.ReadLine());
                        string tipekar = "Karyawan Harian";
                        Console.WriteLine("\n");
                        addkar_harian(tipekar, nik, nama, upahperjam, jamkerja);
                    }

                    else if (tipe == 3){
                        Console.Clear();
                        Console.WriteLine("Isi data Sales\n");
                        Console.Write("NIK\t: ");
                        string nik = Console.ReadLine();
                        Console.Write("Nama\t: ");
                        string nama = Console.ReadLine();
                        Console.Write("Jumlah Penjualan\t: ");
                        int jumlahjual = int.Parse(Console.ReadLine());
                        Console.Write("Komisi\t: ");
                        int komisi = int.Parse(Console.ReadLine());
                        string tipekar = "Sales";
                        Console.WriteLine("\n");
                        add_sales(tipekar, nik, nama, jumlahjual, komisi);
                    }
                }
                else if (menu == 2){
                    hapus_karyawan();
                }
                else if (menu == 3){
                    show();
                }
                else if (menu == 4){
                    keluar = true;
                }
            }

            Console.ReadKey();
        }
    }
}