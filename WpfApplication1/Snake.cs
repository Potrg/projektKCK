using SnakeApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Input;
using WpfSnake.Menu;
using WPFSnake;

namespace WpfSnake
{
    class Snake
    {
        int windowHeight = 350;
        int windowWidth = 550;
        System.Media.SoundPlayer player = new System.Media.SoundPlayer();
        public Snake(int sciany, int sleepTime, bool muzik)
        {
            this.sleepTime = sleepTime;
            this.sciany = sciany;
            this.muzik = muzik;
        }
        enum kierunek : byte
        {
            prawo = 0,
            lewo = 1,
            dol = 2,
            gora = 3
        };
        private bool muzik;
        GameView wyswietl = new GameView();
        Queue<Koordynaty> wonsz = new Queue<Koordynaty>();
        List<Koordynaty> przeszkody = new List<Koordynaty>();
        Random generator = new Random();
        Random generator_liczb = new Random(); // random do losowania koordynat nowych smakołyków
        Koordynaty pokarm;
        Koordynaty pokarm_specjalny;
        
        public int mnoznik = 89; // uzaleznić od poziomu //deski 33 // czesciowe deski 87 // brak granic 121
        public int sciany; //podawane w konstruktorze!
        public int punkty = 0;
        public double sleepTime = 50;// jak długo wąż ma spać - decyduje o szybkości węża
        int punkty_dodatkowe = 0;

        private void losuj_jedzenie()
        {
            do
            {
                pokarm = new Koordynaty(generator_liczb.Next(8, windowHeight),
                    generator_liczb.Next(0, windowWidth));
            }
            while (wonsz.Contains(pokarm) || przeszkody.Contains(pokarm) || pokarm_specjalny.Equals(pokarm));
        }
        private void losuj_jedzenie_specjalne()
        {
            do
            {
                pokarm_specjalny = new Koordynaty(generator.Next(8, windowHeight),
                    generator.Next(0, windowWidth));
            }
            while (wonsz.Contains(pokarm_specjalny) || przeszkody.Contains(pokarm_specjalny) || pokarm_specjalny.Equals(pokarm));
        }
        public void pause()
        {
            wyswietl.pauza();

        }//mod tą funkcje do działania w grze

        public void dodawanie_scian(int value)
        {
            if (value == 1 || value == 2)
            {
                for (int i = 0; i < windowWidth; i++)
                {
                    Koordynaty temppos = new Koordynaty(0, i); przeszkody.Add(temppos);
                    Koordynaty temppos2 = new Koordynaty(windowHeight-1, i); przeszkody.Add(temppos2);
                }

                if (value == 1)
                {
                    for (int i = 6; i < windowHeight / 2; i++)
                    {
                        Koordynaty temppos = new Koordynaty(i, windowWidth - 1); przeszkody.Add(temppos);
                        Koordynaty temppos2 = new Koordynaty(i, 0); przeszkody.Add(temppos2);
                    }
                }
                if (value == 2)
                {
                    for (int i = 6; i < windowHeight; i++)
                    {
                        Koordynaty temppos = new Koordynaty(i, windowWidth - 1); przeszkody.Add(temppos);
                        Koordynaty temppos2 = new Koordynaty(i, 0); przeszkody.Add(temppos2);
                    }
                }
            }
            else if (value == 0)
                przeszkody.Clear();
        }
        public void narodziny_weza()
        {
            for (int i = 1; i <= 10; i++)
            {
                wonsz.Enqueue(new Koordynaty(7, i));
            }
        }

        public void Snake_Init()
        {
            player.SoundLocation = @"C:\content\2.wav";
            if (muzik == true)
            {

                player.Stop();
                //var p1 = new System.Windows.Media.MediaPlayer();
                //p1.Open(new System.Uri(@"E:\Users\The_BuBu\Documents\Visual Studio 2013\Projects\ConsoleApplication2\ConsoleApplication2\bin\Debug\2.wav"));
                //p1.Play();
                //new System.Threading.Thread(() =>
                //{
                //    var c = new System.Windows.Media.MediaPlayer();
                //    c.Open(new System.Uri(@"E:\Users\The_BuBu\Documents\Visual Studio 2013\Projects\ConsoleApplication2\ConsoleApplication2\bin\Debug\2.wav"));
                //    c.Play();
                //}).Start();
                player.PlayLooping();
            }
            double mnoznik_za_lvl = (1 / sleepTime) * 33 + (sciany + 1) * 2;
            //Zmienne :o
            int kierunek_poruszania = (int)kierunek.prawo; // początkowy kierunek (by np wonsz nie wpadl na skałę)
            int licznik_karmienia_weza = 0;// odlicza czas od odtatniego karmienia
            int licznik_karmienia_weza2 = 0;
            int czas_usuniecia_jedzenia = 30000; // jak dłygo jedzenie pozostaje na planszy
            int punkty_ujemne = 0; // punkty ujemne za niezjedzone jesdzenie 
            licznik_karmienia_weza = Environment.TickCount;
            licznik_karmienia_weza2 = Environment.TickCount;
            int temp = 2;


            Koordynaty[] tablica_skretow = new Koordynaty[]
            {
                new Koordynaty(0, 1), // right
                new Koordynaty(0, -1), // left
                new Koordynaty(1, 0), // down
                new Koordynaty(-1, 0), // up
            };
            dodawanie_scian(sciany);
            wyswietl.sciany(przeszkody);//klasa game viewer
            narodziny_weza();
            losuj_jedzenie();
            wyswietl.jedzenie(pokarm, 0);//klasa game viewer
            losuj_jedzenie_specjalne();
            wyswietl.jedzenie(pokarm_specjalny, temp);
            wyswietl.weza(wonsz);//klasa game viewer 
            while (true)//TODO: przerobic na kontrole w wpf
            {

                if (true)
                {
                    //ConsoleKeyInfo kl = Console.ReadKey(false); // przerobić na switcha
                    Key k1 = wyswietl.klawisz;
                    switch (k1)
                    {
                        case Key.Left:
                            if (kierunek_poruszania != (int)kierunek.prawo) kierunek_poruszania = (int)kierunek.lewo;
                            break;
                        case Key.Right:
                            if (kierunek_poruszania != (int)kierunek.lewo) kierunek_poruszania = (int)kierunek.prawo;
                            break;
                        case Key.Up:
                            if (kierunek_poruszania != (int)kierunek.dol) kierunek_poruszania = (int)kierunek.gora;
                            break;
                        case Key.Down:
                            if (kierunek_poruszania != (int)kierunek.gora) kierunek_poruszania = (int)kierunek.dol;
                            break;
                        case Key.P:
                            pause();
                            break;
                    }

                }

                Koordynaty aktualnaGlowa = wonsz.Last();
                Koordynaty nowy_kierunek = tablica_skretow[kierunek_poruszania];

                Koordynaty nowaGlowa = new Koordynaty((int)aktualnaGlowa.row + (int)nowy_kierunek.row,
                    (int)aktualnaGlowa.col + (int)nowy_kierunek.col);

                if (nowaGlowa.col < 0) nowaGlowa.col = windowWidth - 1; ///
                if (nowaGlowa.row < 0) nowaGlowa.row = windowHeight - 1;/// Wanrunki przechodzenia przez sciany
                if (nowaGlowa.row >= windowHeight) nowaGlowa.row = 0;  //// zmiana na wymiary okna w nst projekcie
                if (nowaGlowa.col >= windowWidth) nowaGlowa.col = 0;   ////

                if (wonsz.Contains(nowaGlowa) || przeszkody.Contains(nowaGlowa)) // Warunek kończoncy grę !
                {
                    punkty = (wonsz.Count - 10) * mnoznik * (int)mnoznik_za_lvl - punkty_ujemne + punkty_dodatkowe;
                    if (punkty < 0) punkty = 0;
                    punkty = Math.Max(punkty, 0);
                    wyswietl.muzik = this.muzik;
                    wyswietl.game_over(punkty,muzik);
                    return;
                }

                wonsz.Enqueue(nowaGlowa);// doadnie nowej glowy do kolejki
                wyswietl.usun_stara_glowe(aktualnaGlowa);
                wyswietl.zmien_kierunek_glowy(nowaGlowa, kierunek_poruszania);


                if (nowaGlowa.col == pokarm_specjalny.col && nowaGlowa.row == pokarm_specjalny.row)
                {
                    var p2 = new System.Windows.Media.MediaPlayer();
                    p2.Open(new Uri(@"E:\OneDrive\Documents\Visual Studio 2015\Projects\ConsoleApplication2\ConsoleApplication2\sounds\3.wav"));
                    p2.Play();

                    if (temp == 1)
                    {
                        punkty_ujemne += punkty / 2;
                    }
                    if (temp == 2)
                    {
                        punkty_dodatkowe += 500;
                    }
                    if (temp == 3)
                    {
                        sleepTime += 10;
                        punkty_dodatkowe += 153;
                    }
                    if (temp == 4)
                    {
                        punkty_dodatkowe += 153;
                        sleepTime -= 10;
                    }
                    licznik_karmienia_weza2 = Environment.TickCount;
                    punkty = (wonsz.Count - 10) * mnoznik * (int)mnoznik_za_lvl - punkty_ujemne + punkty_dodatkowe;
                    wyswietl.wyswietl_wynik(Math.Max(punkty, 0));
                    wyswietl.usun_pokarm_lub_ogon(pokarm_specjalny);
                    pokarm_specjalny = default(Koordynaty);

                }
                else if (nowaGlowa.col == pokarm.col && nowaGlowa.row == pokarm.row)
                {
                    //Metoda laternatywna
                    //new System.Threading.Thread(() =>
                    //{
                    //    var c = new System.Windows.Media.MediaPlayer();
                    //    c.Open(new System.Uri(@"E:\Users\The_BuBu\Documents\Visual Studio 2013\Projects\ConsoleApplication2\ConsoleApplication2\bin\Debug\3.wav"));
                    //    c.Play();
                    //}).Start();

                    var p2 = new System.Windows.Media.MediaPlayer();
                    p2.Open(new System.Uri(@"E:\OneDrive\Documents\Visual Studio 2015\Projects\ConsoleApplication2\ConsoleApplication2\sounds\3.wav"));
                    p2.Play();

                    // karmienie weza
                    losuj_jedzenie();
                    licznik_karmienia_weza = Environment.TickCount;
                    punkty = (wonsz.Count - 10) * mnoznik * (int)mnoznik_za_lvl - punkty_ujemne + punkty_dodatkowe;
                    wyswietl.wyswietl_wynik(Math.Max(punkty, 0));
                    wyswietl.jedzenie(pokarm, 0);//klasa game viewer
                }
                else
                {
                    // prouszanie się węża - usunięcie ogona jesli nic nie zjadł
                    Koordynaty last = wonsz.Dequeue(); // uzyskiwanie "adresu" ogona 
                    wyswietl.usun_pokarm_lub_ogon(last);
                }

                if (Environment.TickCount - licznik_karmienia_weza2 >= 25000)
                {
                    wyswietl.usun_pokarm_lub_ogon(pokarm_specjalny);
                    pokarm_specjalny = default(Koordynaty);
                    // random do losowania koordynat nowych smakołyków
                    temp = generator.Next(1, 5);
                    if (temp == 1)
                    {
                        losuj_jedzenie_specjalne();
                        wyswietl.jedzenie(pokarm_specjalny, 1);
                    }
                    if (temp == 2)
                    {
                        losuj_jedzenie_specjalne();
                        wyswietl.jedzenie(pokarm_specjalny, 2);
                    }
                    if (temp == 3)
                    {
                        losuj_jedzenie_specjalne();
                        wyswietl.jedzenie(pokarm_specjalny, 3);
                    }
                    if (temp == 4)
                    {
                        losuj_jedzenie_specjalne();
                        wyswietl.jedzenie(pokarm_specjalny, 4);
                    }
                    licznik_karmienia_weza2 = Environment.TickCount;
                }
                if (Environment.TickCount - licznik_karmienia_weza >= czas_usuniecia_jedzenia) // usuwanie pokarmu po okreslonym czasie
                {
                    punkty_ujemne = punkty_ujemne + 50;
                    wyswietl.usun_pokarm_lub_ogon(pokarm);
                    losuj_jedzenie();
                    licznik_karmienia_weza = Environment.TickCount;
                }
                wyswietl.jedzenie(pokarm, 0);
                //sleepTime -= 0.001;

                Thread.Sleep((int)sleepTime);
            }
        }

      
    }
}
