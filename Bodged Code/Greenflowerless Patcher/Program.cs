using Marathon.Formats.Archive;
using Marathon.IO;
using System.IO.Compression;

namespace Greenflowerless_Patcher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Check the user has actually given us the Greenflower folder...
            if (args.Length < 1)
            {
                Console.WriteLine("Drag and drop your Greenflower Zone mod folder into this application's executable.");
                Console.ReadKey();
            }

            // Proceed if they have given us SOMETHING.
            else
            {
                // Check the mod.ini for sanity's sake.
                if (File.Exists($@"{args[0]}\mod.ini"))
                {
                    // Load the mod.ini.
                    string[] modINICheck = File.ReadAllLines($@"{args[0]}\mod.ini");

                    // Halt if this isn't Greenflower's, or if it's already patched..
                    if (modINICheck[1] != "Title=\"Greenflower Zone\"")
                    {
                        if (modINICheck[1] == "Title=\"Greenflowerless Zone\"")
                        {
                            Console.WriteLine($"'{args[0]}' has already been patched.");
                            Console.ReadKey();
                            return;
                        }

                        Console.WriteLine($"Incorrect 'mod.ini' file in '{args[0]}'.");
                        Console.ReadKey();
                        return;
                    }

                    // Proceed if it is.
                    else
                    {
                        // List of file names to remove.
                        string[] flowerNames = new[] { "BUS1A0", "BUS2A0", "FWR1A0", "FWR2A0", "FWR3A0", "BST1A0", "BST2A0", "JPLAB0", "THZPA0" };

                        // Loop through all the stage archives in the mod's win32 folder.
                        foreach (string arcFile in Directory.GetFiles($@"{args[0]}\win32\archives", "stage_*.arc"))
                        {
                            // Load and extract this archive to disk, then let go of it.
                            U8Archive arc = new(arcFile, ReadMode.IndexOnly);
                            arc.Extract($@"{args[0]}\win32\archives\{Path.GetFileNameWithoutExtension(arcFile)}");
                            arc.Dispose();

                            // Loop through the XNOs in this archive. If one has a matching name, then delete it.
                            foreach (string xnoFile in Directory.GetFiles($@"{args[0]}\win32\archives\{Path.GetFileNameWithoutExtension(arcFile)}", "*.xno", SearchOption.AllDirectories))
                                if (flowerNames.Any(xnoFile.Contains))
                                    File.Delete(xnoFile);

                            // Create and resave the edited archive.
                            arc = new($@"{args[0]}\win32\archives\{Path.GetFileNameWithoutExtension(arcFile)}", true, CompressionLevel.Optimal);
                            arc.Save(arcFile);

                            // Delete this archive's work directory.
                            Directory.Delete($@"{args[0]}\win32\archives\{Path.GetFileNameWithoutExtension(arcFile)}", true);
                        }

                        // Edit the mod.ini.
                        modINICheck[1] = "Title=\"Greenflowerless Zone\"";
                        File.WriteAllLines($@"{args[0]}\mod.ini", modINICheck);

                        // Rename the mod directory.
                        Directory.Move(args[0], args[0].Replace("Greenflower Zone", "Greenflowerless Zone"));
                    }
                }

                // Halt if there just isn't a mod.ini file.
                else
                {
                    Console.WriteLine($"No 'mod.ini' file found in '{args[0]}'.");
                    Console.ReadKey();
                }
            }
        }
    }
}