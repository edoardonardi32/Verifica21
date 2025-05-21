
List<string> leggiFile (string filepath)
{
    List<string> list = new List<string>();
    string[] lines = File.ReadAllLines(filepath);
    for (int i = 1; i < lines.Length; i++)
    {
        list.Add(lines[i]);

 
    }
    return list;
}
 void FiltraPerTempo (string filepath, int tempo)
{
    string[] lines = File.ReadAllLines(filepath);
    for (int i = 1; i < lines.Length; i++)
    {
        string[] line = lines[i].Split(';');
        if (int.Parse(line[4]) <= tempo)
        {
            Console.WriteLine(line[0] + " " + line[1] + " - " + line[3] + "(" +line[4]+" min)");
        }
    }
}
List<string> CercaPerScuola(string filepath, string scuola)
{
    List<string> StudentiScuola = new List<string>();
    string[] lines = File.ReadAllLines(filepath);
    for (int i = 1; i < lines.Length; i++)
    {
        string[] line = lines[i].Split(';');
        if (line[3] == scuola)
        {
            StudentiScuola.Add(line[0]);
            StudentiScuola.Add(line[1]);
            StudentiScuola.Add("");
        }
    }
    
    return StudentiScuola;
}
void CalcolaStatistiche(string filepath)
{
    int tempo = 0;
    string[] Nomelento = new string[2];
    int lento = 0;
    string[] lines = File.ReadAllLines(filepath);
    for (int i = 1; i < lines.Length; i++)
    {
        string[] line = lines[i].Split(';');
        tempo = tempo + int.Parse(line[4]);
        if (int.Parse(line[4]) > lento)
        {
            lento = int.Parse(line[4]);
            Nomelento[0] = line[0];
            Nomelento[1] = line[1];
        }

    }
    tempo = tempo / lines.Length - 1;
    Console.WriteLine("Tempo Medio = " + tempo);
    Console.WriteLine("Partecipanti total = " + (lines.Length - 1));
    Console.WriteLine("Partecipante più lento = " + Nomelento[0] + " " + Nomelento[1]);
}
void CalcolaPodio(string filepath)
{
    List<string> podi01 = new List<string>();
    List<string> podi02 = new List<string>();
    List<string> podi03 = new List<string>();
    int podio1=0;
    int podio2=0;
    int podio3=0;
    string[] lines = File.ReadAllLines(filepath);
    for (int i = 1; i < lines.Length; i++)
    {
        string[] line = lines[i].Split(';');
        if(int.Parse(line[4]) > podio1)
        {

            podi02[0] = podi01[0];
            podi02[1] = podi01[1];
            podi02[2] = podi01[2];
            podi02[4] = podi01[4];

            podi01[0]=(line[0]);
            podi01[1]=(line[1]);
            podi01[2]=(line[3]);
            podi01[4] = (line[4]);

        }
        else if (int.Parse(line[4]) > podio2)
        {
            podi03[0] = podi02[0];
            podi03[1] = podi02[1];
            podi03[2] = podi02[2];
            podi03[4] = podi02[4];

            podi02[0] = (line[0]);
            podi02[1] = (line[1]);
            podi02[2] = (line[3]);
            podi02[4] = (line[4]);
        }
        if (int.Parse(line[4]) > podio3)
        {
            podi03[0] = (line[0]);
            podi03[1] = (line[1]);
            podi03[2] = (line[3]);
            podi03[4] = (line[4]);
        }
    }
    Console.WriteLine("1 - " + podi01[0] + podi01[1] +" - "+ podi01[3] +" ("+ podi01[4]+" min )");
    Console.WriteLine("2 - " + podi02[0] + podi02[1] + " - " + podi02[3] + " (" + podi02[4] + " min )");
    Console.WriteLine("3 - " + podi03[0] + podi03[1] + " - " + podi03[3] + " (" + podi03[4] + " min )");
}
FiltraPerTempo( "maratona.csv",65);
CalcolaStatistiche("maratona.csv");
string scuola = "IIS_Volta";
string outputFile = "Partecipanti" + scuola + ".txt";
StreamWriter streamwriter =  new StreamWriter(outputFile);
List<string> studenti = CercaPerScuola("maratona.csv", "IIS Volta");
foreach( string x in studenti)
{
    
    streamwriter.WriteLine(x);

}
 streamwriter.Close();
CalcolaPodio("maratona.csv");