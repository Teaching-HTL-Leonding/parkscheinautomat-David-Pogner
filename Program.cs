double Münzen = 0.00;
int Minuten = 0, Stunden = 0;
bool Zeit = false;

Console.Clear();

PrintWelcome();
EnterCoins();
PrintParkingTime();
PrintDonation();

void PrintWelcome(){
    Console.WriteLine("Parkscheinautomat mit Mindestparkdauer 30 Min und Höchstparkdauer 1:30 Stunden");
    Console.WriteLine("Zulässige Münzen: 50 (Cents), 10 (Cents), 20 (Cents), 50 (Cents), 1 (Euro), 2 (Euro)");
    Console.WriteLine("Parkschein drucken mit d oder D");
}

void EnterCoins()
{
    bool erledigt = false;

    do
    {
        Console.Write("Bitte werfen Sie eine Münze ein: ");
        string input = Console.ReadLine()!;

        if (input == "d" || input == "D"){
            if (Münzen > 0.5)
            {
                erledigt = true;
            }
            else
            {
                Console.WriteLine("Der Mindesteinfurf beträgt 50");
            }
        }
        else
        {
            if (input == "1" || input == "2" || input == "5" || input == "10" || input == "20" || input == "50")
            {
                double coin = double.Parse(input);
                if(coin == 1)
                {
                    Münzen += 1;
                    AddParkingTime(coin);
                } 
                else if(coin == 2) 
                {
                    Münzen += 2;
                    AddParkingTime(coin);
                }
                else 
                {
                    AddParkingTime(coin);
                    Münzen += coin / 100;
                }
                Console.WriteLine($"Parkzeit bisher: {Stunden}:{Minuten:00}");
            }
            else
            {
                Console.WriteLine("Ihre Eingabe ist nicht gültig!");
            }
        }
    } while (!erledigt || !Zeit);
}

void AddParkingTime(double Münzen){
    switch (Münzen)
    {
        case 1:
            Stunden++;
            break;
        case 2:
            Stunden += 2;
            break;
        case 5:
            Stunden += 3;
            break;
        case 10:
            Stunden += 6;
            break;
        case 20:
            Minuten += 12;
            break;
        case 50:
            Minuten += 30;
            break;
    }
    if(Minuten >= 60) 
    {
        Minuten -= 60;
        Stunden++;
    }
    if(Stunden > 1 && Minuten > 30 || Stunden > 1) 
    {
        PrintParkingTime();
        Zeit = true;
    }
}

void PrintParkingTime()
{
    Console.WriteLine($"Sie dürfen {Stunden}:{Minuten:00} Stunden parken");
}

void PrintDonation()
{
    int Euro = 0;
    double Cent = 0;
    if(Münzen >= 1.50)
    {
        Münzen -= 1.50;
        do 
        {   
            Euro += 1;
            Münzen -= 1;
        }
        while(Münzen >= 1);
        
        Cent = (Münzen * 100);
    }
    Console.WriteLine($"Danke für Ihre Spende von {Euro} Euro {Cent} Cent");   
}