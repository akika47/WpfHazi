using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using Microsoft.Win32;
namespace WpfOsztalyzas
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		string fajlNev = "naplo.txt";
		ObservableCollection<Osztalyzat> jegyek = new ObservableCollection<Osztalyzat>();

		public MainWindow()
		{
			InitializeComponent();
			// todo Fájlok kitallózásával tegye lehetővé a naplófájl kiválasztását! OK
			// Ha nem választ ki semmit, akkor "naplo.csv" legyen az állomány neve. A későbbiekben ebbe fog rögzíteni a program.
			OpenFileDialog ofd = new OpenFileDialog();

			if ((bool)ofd.ShowDialog()! && ofd.FileName.EndsWith(".csv"))
			{
				fajlNev = ofd.FileName;
			}
			using (StreamReader sr = new StreamReader(fajlNev))
			{
				while (!sr.EndOfStream)
				{
					string[] SplitString = sr.ReadLine()!.Split(";");
					jegyek.Add(new Osztalyzat(SplitString[0], SplitString[1], SplitString[2], Convert.ToInt32(SplitString[^1])));
				}
			}
			// todo A kiválasztott naplót egyből töltse be és a tartalmát jelenítse meg a datagrid-ben! OK
			dgJegyek.ItemsSource = jegyek;
			FilePath_txt.Text = fajlNev;
			Grades_txt.Text = $"Jegyek száma: {jegyek.Count()}, Jegyek átlaga: {jegyek.Average(x => x.Jegy):.0}";
		}

		private void btnRogzit_Click(object sender, RoutedEventArgs e)
		{

			string[] NameSplit = txtNev.Text.Split(" ");
			if (NameSplit.Count() == 1)
			{
				MessageBox.Show("A névnek minimum 2 szóból kell állnia", "NameError", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}
			if (Array.FindAll(NameSplit, x => x.Count() < 3).ToArray().Count() > 0)
			{
				MessageBox.Show("A névnek szavanként minimum 3 karakterből kell állnia", "ShortNameError", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}
			if (DateTime.Compare(datDatum.SelectedDate!.Value, DateTime.Now) > 0)
			{
				MessageBox.Show("Nem lehet jövőbeli dátum!", "DateError", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			//todo A rögzítés mindig az aktuálisan megnyitott naplófájlba történjen! OK


			//A CSV szerkezetű fájlba kerülő sor előállítása
			string csvSor = $"{txtNev.Text};{datDatum.Text};{cboTantargy.Text};{sliJegy.Value}";
			//Megnyitás hozzáfűzéses írása (APPEND)
			StreamWriter sw = new StreamWriter(fajlNev, append: true);
			sw.WriteLine(csvSor);
			sw.Close();
			//todo Az újonnan felvitt jegy is jelenjen meg a datagrid-ben! OK
			jegyek.Add(new Osztalyzat(txtNev.Text, datDatum.Text, cboTantargy.Text, Convert.ToInt32(sliJegy.Value)));
			Grades_txt.Text = $"Jegyek száma: {jegyek.Count()}, Jegyek átlaga: {jegyek.Average(x => x.Jegy):.0}";

		}

		private void btnBetolt_Click(object sender, RoutedEventArgs e)
		{
			jegyek.Clear();  //A lista előző tartalmát töröljük
			StreamReader sr = new StreamReader(fajlNev); //olvasásra nyitja az állományt
			while (!sr.EndOfStream) //amíg nem ér a fájl végére
			{
				string[] mezok = sr.ReadLine()!.Split(";"); //A beolvasott sort feltördeli mezőkre
															//A mezők értékeit felhasználva létrehoz egy objektumot
				Osztalyzat ujJegy = new Osztalyzat(mezok[0], mezok[1], mezok[2], int.Parse(mezok[3]));
				jegyek.Add(ujJegy); //Az objektumot a lista végére helyezi
			}
			sr.Close(); //állomány lezárása

			//A Datagrid adatforrása a jegyek nevű lista lesz.
			//A lista objektumokat tartalmaz. Az objektumok lesznek a rács sorai.
			//Az objektum nyilvános tulajdonságai kerülnek be az oszlopokba.
			dgJegyek.ItemsSource = jegyek;
			Grades_txt.Text = $"Jegyek száma: {jegyek.Count()}, Jegyek átlaga: {jegyek.Average(x => x.Jegy):.0}";
		}


		//todo Felület bővítése: Az XAML átszerkesztésével biztosítsa, hogy láthatóak legyenek a következők! OK
		// - A naplófájl neve
		// - A naplóban lévő jegyek száma
		// - Az átlag

		//todo Új elemek frissítése: Figyeljen rá, ha új jegyet rögzít, akkor frissítse a jegyek számát és az átlagot is! OK

		//todo Helyezzen el alkalmas helyre 2 rádiónyomógombot! OK
		//Feliratok: [■] Vezetéknév->Keresztnév [O] Keresztnév->Vezetéknév
		//A táblázatban a név azserint szerepeljen, amit a rádiónyomógomb mutat!
		//A feladat megoldásához használja fel a ForditottNev metódust!
		//Módosíthatja az osztályban a Nev property hozzáférhetőségét!
		//Megjegyzés: Felételezzük, hogy csak 2 tagú nevek vannak

		private void SwapName(object? sender, RoutedEventArgs e)
		{
			foreach (Osztalyzat osztalyzat in jegyek)
			{
				osztalyzat.ForditottNev();
			}
			dgJegyek.Items.Refresh();
		}
	}
}

