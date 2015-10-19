using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    struct Koordynaty// pozycje do kurde wszystkiego
    {
        public int row;
        public int col;
        public Koordynaty(int row, int col)
        {
            this.row = row;
            this.col = col;
        }
    }

    class Snake
    {
        public Snake(int sciany, int sleepTime)
    {
    this.sleepTime = sleepTime;
    this.sciany = sciany;
    }
        enum kierunek : byte 
        { 
            prawo = 0, 
            lewo = 1, 
            dol = 2, 
            gora = 3 
        };
        GameViewer wyswietl = new GameViewer();
        Queue<Koordynaty> wonsz = new Queue<Koordynaty>();
        List<Koordynaty> przeszkody = new List<Koordynaty>();
        Random generator_liczb = new Random(); // random do losowania koordynat nowych smakołyków
        Koordynaty pokarm;
        Koordynaty pokarm_specjalny;
        public bool muzik;
        public int mnoznik = 100; // uzaleznić od poziomu //deski 33 // czesciowe deski 87 // brak granic 121
        public int sciany; //podawane w konstruktorze!
        public int punkty = 0;
        double sleepTime = 50;// jak długo wąż ma spać - decyduje o szybkości węża
        int punkty_dodatkowe = 0;

        private void losuj_jedzenie()
        {
            do
            {
                pokarm = new Koordynaty(generator_liczb.Next(8, Console.WindowHeight),
                    generator_liczb.Next(0, Console.WindowWidth));
            }
            while (wonsz.Contains(pokarm) || przeszkody.Contains(pokarm));
        }
        private void losuj_jedzenie_specjalne()
        {
            do
            {
                pokarm_specjalny = new Koordynaty(generator_liczb.Next(8, Console.WindowHeight),
                    generator_liczb.Next(0, Console.WindowWidth));
            }
            while (wonsz.Contains(pokarm_specjalny) || przeszkody.Contains(pokarm_specjalny) || pokarm.Equals(pokarm_specjalny));
        }
        public void pause()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(0, 6);
            Console.Write("  PAUSE__CLICK_P_TO_CONTINUE_THE_GAME___||||___CLICK_Esc_TO_exit_THE_GAME___||||___PAUSE__CLICK_P_TO_CONTINUE_THE_GAME___||||___CLICK_Esc_TO_exit_THE_GAME___||||___PAUSE__CLICK_P_TO_CONTINUE_THE_GAME ");
            
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo kl2 = Console.ReadKey(false); // przerobić na switcha
                    if (kl2.Key == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        Menu_class menu = new Menu_class(muzik);
                        menu.reset_menu(muzik);
                        menu.highlight_menu(0,muzik);
                        menu.menu_conroler();
                        //wejdz do głównego menu
                    }
                    if (kl2.Key == ConsoleKey.P)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.SetCursorPosition(0, 6);
                        Console.Write("                                                                                                                                                                                                        ");
                        wyswietl.sciany(przeszkody);
                        break;}}}}
        
        public void dodawanie_scian(int value)
        {
            if (value == 1 || value == 2)
            {
                for (int i = 0; i < Console.WindowWidth; i++)
                {
                    Koordynaty temppos = new Koordynaty(6, i); przeszkody.Add(temppos);
                    Koordynaty temppos2 = new Koordynaty(59, i); przeszkody.Add(temppos2);
                }

                if (value == 1)
                {
                    for (int i = 6; i < Console.WindowHeight / 2; i++)
                    {
                        Koordynaty temppos = new Koordynaty(i, Console.WindowWidth - 1); przeszkody.Add(temppos);
                        Koordynaty temppos2 = new Koordynaty(i, 0); przeszkody.Add(temppos2);
                    }
                }
                if (value == 2)
                {
                    for (int i = 6; i < Console.WindowHeight; i++)
                    {
                        Koordynaty temppos = new Koordynaty(i, Console.WindowWidth - 1); przeszkody.Add(temppos);
                        Koordynaty temppos2 = new Koordynaty(i, 0); przeszkody.Add(temppos2);
                    }
                }
            }
            else if(value==0)
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
            Console.CursorSize = 12;
            Console.BufferHeight = 60;
            Console.BufferWidth = 201;
            Console.SetWindowSize(200, 60);
            //Zmienne :o
            int kierunek_poruszania = (int)kierunek.prawo; // początkowy kierunek (by np wonsz nie wpadl na skałę)
            int licznik_karmienia_weza = 0;// odlicza czas od odtatniego karmienia
            int licznik_karmienia_weza2 = 0;
            int czas_usuniecia_jedzenia = 40000; // jak dłygo jedzenie pozostaje na planszy
            int punkty_ujemne = 0; // punkty ujemne za niezjedzone jesdzenie 
            licznik_karmienia_weza = Environment.TickCount;
            licznik_karmienia_weza2 = Environment.TickCount;


            Koordynaty[] tablica_skretow = new Koordynaty[]
            {
                new Koordynaty(0, 1), // right
                new Koordynaty(0, -1), // left
                new Koordynaty(1, 0), // down
                new Koordynaty(-1, 0), // up
            };
            losuj_jedzenie_specjalne();
            dodawanie_scian(sciany);
            wyswietl.sciany(przeszkody);//klasa game viewer
            narodziny_weza();
            losuj_jedzenie();
            wyswietl.jedzenie(pokarm,0);//klasa game viewer
            wyswietl.weza(wonsz);//klasa game viewer 
            while (true)
            {

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo kl = Console.ReadKey(false); // przerobić na switcha
                    switch (kl.Key)
                    {
                        case ConsoleKey.LeftArrow:
                            if (kierunek_poruszania != (int)kierunek.prawo) kierunek_poruszania = (int)kierunek.lewo;
                            break;
                        case ConsoleKey.RightArrow:
                            if (kierunek_poruszania != (int)kierunek.lewo) kierunek_poruszania = (int)kierunek.prawo;
                            break;
                        case ConsoleKey.UpArrow:
                            if (kierunek_poruszania != (int)kierunek.dol) kierunek_poruszania = (int)kierunek.gora;
                            break;
                        case ConsoleKey.DownArrow:
                            if (kierunek_poruszania != (int)kierunek.gora) kierunek_poruszania = (int)kierunek.dol;
                            break;
                        case ConsoleKey.P:
                            pause();
                            break;
                    }

                }

                Koordynaty aktualnaGlowa = wonsz.Last();
                Koordynaty nowy_kierunek = tablica_skretow[kierunek_poruszania];

                Koordynaty nowaGlowa = new Koordynaty(aktualnaGlowa.row + nowy_kierunek.row,
                    aktualnaGlowa.col + nowy_kierunek.col);

                if (nowaGlowa.col < 0) nowaGlowa.col = Console.WindowWidth - 1; ///
                if (nowaGlowa.row < 6) nowaGlowa.row = Console.WindowHeight - 1;/// Wanrunki przechodzenia przez sciany
                if (nowaGlowa.row >= Console.WindowHeight) nowaGlowa.row = 6;  ////
                if (nowaGlowa.col >= Console.WindowWidth) nowaGlowa.col = 0;   ////

                if (wonsz.Contains(nowaGlowa) || przeszkody.Contains(nowaGlowa)) // Warunek kończoncy grę !
                {    
                    punkty = (wonsz.Count - 10) * mnoznik - punkty_ujemne + punkty_dodatkowe;
                    if (punkty < 0) punkty = 0;
                    punkty = Math.Max(punkty, 0);
                    wyswietl.muzik = this.muzik;
                    wyswietl.game_over(punkty);
                    Thread.Sleep(2000);
                    Console.ReadKey(false);
                    return;
                }

                wonsz.Enqueue(nowaGlowa);// doadnie nowej glowy do kolejki
                wyswietl.usun_stara_glowe(aktualnaGlowa);
                wyswietl.zmien_kierunek_glowy(nowaGlowa, kierunek_poruszania);

               
                    if (nowaGlowa.col == pokarm_specjalny.col && nowaGlowa.row == pokarm_specjalny.row)
                    {
                        licznik_karmienia_weza2 = Environment.TickCount;
                        //losuj_jedzenie_specjalne();
                        wyswietl.usun_pokarm_lub_ogon(pokarm_specjalny);
                    }
                    if (Environment.TickCount - licznik_karmienia_weza2 >= 20000)
                        {
                        int temp = generator_liczb.Next(1,5);
                        if (temp==1)
                        {
                            losuj_jedzenie_specjalne();
                            wyswietl.jedzenie(pokarm, 1);
                        }
                        if (temp == 2)
                        {
                            losuj_jedzenie_specjalne();
                            wyswietl.jedzenie(pokarm, 2);
                        }
                        if (temp == 3)
                        {
                            losuj_jedzenie_specjalne();
                            wyswietl.jedzenie(pokarm, 3);
                        }
                        if (temp == 4)
                        {
                            losuj_jedzenie_specjalne();
                            wyswietl.jedzenie(pokarm, 4);
                        }

                        
                    }
                

                if (nowaGlowa.col == pokarm.col && nowaGlowa.row == pokarm.row)
                {
                    // karmienie weza
                    losuj_jedzenie();
                    licznik_karmienia_weza = Environment.TickCount;
                    punkty = (wonsz.Count - 10) * mnoznik - punkty_ujemne + punkty_dodatkowe;
                    wyswietl.wyswietl_wynik(Math.Max(punkty, 0));
                    wyswietl.jedzenie(pokarm,0);//klasa game viewer
                }
                else
                {
                    // prouszanie się węża - usunięcie ogona jesli nic nie zjadł
                    Koordynaty last = wonsz.Dequeue(); // uzyskiwanie "adresu" ogona 
                    wyswietl.usun_pokarm_lub_ogon(last);
                }
                if (Environment.TickCount - licznik_karmienia_weza >= czas_usuniecia_jedzenia) // usuwanie pokarmu po okreslonym czasie
                {
                    punkty_ujemne = punkty_ujemne + 50;
                    wyswietl.usun_pokarm_lub_ogon(pokarm);
                    losuj_jedzenie();
                    licznik_karmienia_weza = Environment.TickCount;
                }
                wyswietl.jedzenie(pokarm,0);
                sleepTime -= 0.001;

                Thread.Sleep((int)sleepTime);
            }
        }
    }
}
