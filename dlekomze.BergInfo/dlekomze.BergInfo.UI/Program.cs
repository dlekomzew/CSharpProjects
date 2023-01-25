﻿using dlekomze.BergInfo.Entity;
using dlekomze.BergInfo.SqlServer;

BergInfoDbContext context = new BergInfoDbContext();
IBergRepository bergRepository = new BergRepository(context);

Console.WriteLine("Auswahlmenü:");
Console.WriteLine();
Console.WriteLine("(1) Alle Berge ausgeben");
Console.WriteLine("(2) Berg anhand seiner ID auslesen");
Console.WriteLine("(3) Berg anhand seines Namens auslesen");
Console.WriteLine();
Console.WriteLine("(5) Ändern eines bestehenden Berges");
Console.WriteLine("(6) Löschen eines bestehenden Berges");
Console.WriteLine();
Console.WriteLine("(9) Programmende");
Console.WriteLine();
Console.Write("Ihre auswahl: ");

ConsoleKeyInfo consoleKey = Console.ReadKey();
switch (consoleKey.Key)
{
	case ConsoleKey.D1:
		AusgabeBerge();
		break;
	case ConsoleKey.D2:
		AusgabeBergID();
		break;
	case ConsoleKey.D3:
		AusgabeBergName();
		break;
	case ConsoleKey.D5:
		AendernBerg();
		break;
	case ConsoleKey.D6:
		
		break;
}

Console.WriteLine();
Console.WriteLine("Bitte drücken Sie eine beliebige Taste...");
Console.ReadKey();

void AusgabeBerge() {
	Console.Clear();
	AusgabeUeberschrift("Alle erfassten Berge");
	bergRepository.GetAll().ToList().ForEach(b =>
		Console.WriteLine($"{b.ID,3}: {b.Name,-30} ({b.Hoehe} m) Erstbesteigung: {b.Ersbesteigung}")
	);
}

void AusgabeBergID()
{
	Console.Clear();
	AusgabeUeberschrift("Berg anhand seiner ID ermitteln");
	int id = GetID();
	Console.WriteLine();

	Berg? berg = bergRepository.Get(id);
	if (berg is null)
	{
		Console.WriteLine($"Der Berg mit der ID {id} wurde nicht gefunden");
		return;
	}

	AusgebenBerg(berg);
}

void AusgabeBergName()
{
	Console.Clear();
	AusgabeUeberschrift("Berg anhand seines Namen ermitteln");
	Console.Write("Bitte geben Sie den Namen eines Berges ein: ");
	string name = Console.ReadLine()?? "";
	Console.WriteLine();

	Berg? berg = bergRepository.GetByName(name);
	if (berg is null)
	{
		Console.WriteLine($"Der Berg mit dem Namen {name} wurde nicht gefunden");
		return;
	}

	AusgebenBerg(berg);
}

void AendernBerg()
{
	Console.Clear();
	AusgabeUeberschrift("Bestehenden Berg ändern");
	int id = GetID();
	Berg? berg = bergRepository.Get(id);
	if (berg is null)
	{
		Console.WriteLine($"Der Berg mit der ID {id} wurde nicht gefunden und kann daher nicht geändert werden");
		return;
	}

	Console.Write($"Name [{berg.Name}]: ");
}

void GetNewProperty(Berg berg, Func<string,bool> isValidInput) // TODO: continue here
{
	bool valid = false;
	while (!valid)
	{
		Console.Write($"Name [{berg.Name}]: ");
		string input = Console.ReadLine() ?? "";
		valid = isValidInput(input) || input == "";
	}
}

void AusgebenBerg(Berg berg)
{
	Console.WriteLine($"ID: {berg.ID}");
	Console.WriteLine($"Name: {berg.Name}");
	Console.WriteLine($"Hoehe: {berg.Hoehe}");
	Console.WriteLine($"Erstbesteigung: {berg.Ersbesteigung}");
}

void AusgabeUeberschrift(string ueberschrift)
{
	Console.WriteLine(ueberschrift);
	Console.WriteLine(new String('=', ueberschrift.Length));
}

static int GetID()
{
	bool ok = false;
	int id = 0;
	while (!ok)
	{
		Console.Write("Bitte geben Sie die ID eines Berges ein: ");
		ok = int.TryParse(Console.ReadLine(), out id);
	}

	return id;
}