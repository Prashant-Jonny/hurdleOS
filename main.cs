// jOS

using System;

namespace jOS
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			String USERDIR = "/Users/jacobgarby/jOS/Users/";
			String JOSDIR = "/Users/jacobgarby/jOS/";

			Console.WriteLine ("Hello! Welcome to");
			Console.WriteLine (" _                   _ _       ____   _____ ");
			Console.WriteLine ("| |                 | | |     / __ \\ / ____|");
			Console.WriteLine ("| |__  _   _ _ __ __| | | ___| |  | | (___  ");
			Console.WriteLine ("| '_ \\| | | | '__/ _` | |/ _ \\ |  | |\\___ \\ ");
			Console.WriteLine ("| | | | |_| | | | (_| | |  __/ |__| |____) | hurdleOS v0.004");
			Console.WriteLine ("|_| |_|\\__,_|_|  \\__,_|_|\\___|\\____/|_____/ ");

			Console.ResetColor ();

			//Check if atleast 1 user exists
			string dirPath = USERDIR;
			if (System.IO.Directory.GetFiles (dirPath).Length - 1 == 0 && System.IO.Directory.GetDirectories (dirPath).Length == 0) {
				Console.WriteLine ("No users exist. Creating a new one!");
				Console.WriteLine ("What would you like your username to be?\n");
				String forced_new_user = Console.ReadLine ();
				Console.WriteLine ("And now choose a password.");
				String forced_new_pass = Console.ReadLine ();
				System.IO.Directory.CreateDirectory (USERDIR + forced_new_user);
				System.IO.Directory.CreateDirectory (USERDIR + forced_new_user + "/documents");
				System.IO.Directory.CreateDirectory (USERDIR + forced_new_user + "/pictures");
				System.IO.Directory.CreateDirectory (USERDIR + forced_new_user + "/music");
				System.IO.Directory.CreateDirectory (USERDIR + forced_new_user + "/_system_info");
				System.IO.File.WriteAllText (USERDIR + forced_new_user + "/_system_info/pass.txt", forced_new_pass);
			}

			// BEGIN LOGIN
			Boolean logged_in = false;
			while (logged_in == false) {
				Console.Write ("Type your username.. ");
				String userIN = Console.ReadLine ();
				Console.Write ("Now type your password.. ");
				String passIN = Console.ReadLine ();
				if (System.IO.Directory.Exists (USERDIR + userIN)) {
					String actual_pass = System.IO.File.ReadAllText (USERDIR + userIN + "/_system_info/pass.txt");
					if (actual_pass == passIN) {
						Console.WriteLine ("Correct password!\n");
						logged_in = true;
					}
					else {
						Console.WriteLine ("Incorrect password.");
					}
				} else {
					Console.WriteLine("This user doesn't exist.");
				}
			}
			// END LOGIN
			while (true) {
				Console.ForegroundColor = ConsoleColor.DarkMagenta; //  <--- Input prompt colour
				Console.Write ("\n>>> ");Console.ResetColor();
				String comd = Console.ReadLine ();
				Console.WriteLine ();

				if (comd == "credits") {
					Console.WriteLine ("Currently running jOS v0.001!\n");
					Console.WriteLine ("Code...............Jacob Garby (j.garby@icloud.com)");
					Console.WriteLine ("Written on.........Xamarin Studio (http://(xamarin.com)");

				} else if (comd == "help") {
					Console.WriteLine ("Here's a list of all commands and their uses!\n");
					Console.WriteLine ("credits............Displays the credits and jOS version");
					Console.WriteLine ("help...............Displays this list");
					Console.WriteLine ("newuser............User setup wizard");
					Console.WriteLine ("clear..............Clears the current screen");

				} else if (comd == "newuser") {
					Console.Write ("What do you want your new username to be?\n");
					String new_user = Console.ReadLine ();
					if (!System.IO.Directory.Exists (USERDIR + new_user)) {
						System.IO.Directory.CreateDirectory (USERDIR + new_user);
						System.IO.Directory.CreateDirectory (USERDIR + new_user + "/documents");
						System.IO.Directory.CreateDirectory (USERDIR + new_user + "/pictures");
						System.IO.Directory.CreateDirectory (USERDIR + new_user + "/music");
						System.IO.Directory.CreateDirectory (USERDIR + new_user + "/_system_info");
						Console.Write ("Now, choose a password.\n");
						String new_pass = Console.ReadLine ();
						System.IO.File.WriteAllText (USERDIR + new_user + "/_system_info/pass.txt", new_pass);
					} else {
						Console.WriteLine ("This user already exists.");
					}
				} else if (comd == "clear") {
					int x = 0;
					while (x < 100) {
						Console.WriteLine (" ");
						x += 1;
					}
				} else if (comd == "colours") {
					Type type = typeof(ConsoleColor);
					Console.ForegroundColor = ConsoleColor.White;
					foreach (var name in Enum.GetNames(type))
					{
						Console.BackgroundColor = (ConsoleColor)Enum.Parse(type, name);
						Console.WriteLine(name);
					}
					Console.BackgroundColor = ConsoleColor.Black;
					foreach (var name in Enum.GetNames(type))
					{
						Console.ForegroundColor = (ConsoleColor)Enum.Parse(type, name);
						Console.WriteLine(name);
					}
				}
				else {
					Console.WriteLine (comd);
				}
			}
		}
	}
}
