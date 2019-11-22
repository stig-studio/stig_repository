#include <iostream> // подключение библиотеки ввода/вывода
#include <Windows.h>
#include <time.h>

using namespace std; // подключение стандартного пространства имен

void Bank_on_bones(int);

int main(void)
{
	system("color 0E");

	int money = 10;

	cout << " ______                                                      ______" << endl;
	cout << "|  __  |                       __    __                     |  __  |" << endl;
	cout << "| |__| |                      |  | /  /                     | |__| |                     _____  ______" << endl;
	cout << "|  __  /  ______    ___    __ |  |/  /   ______  ___    __  |  ___ /  ______  ___    __ |  __ ||   ___|" << endl;
	cout << "| |  | \\ |  __  |  |    \\ |  ||     \\   |  __  ||    \\ |  | | |  | \\ |  __  ||    \\ |  ||  ___||___" << endl;
	cout << "| |__|  || |__|  \\ |  |\\ \\|  ||  |\\  \\  | |__| ||  |\\ \\|  | | |__|  || |__| ||  |\\ \\|  || |___  ___|  |" << endl;
	cout << "|_______||______| \\|__| \\____||__| \\__\\ |______||__| \\____| |_______||______||__| \\____||_____||______|" << endl;

	int game;
	cout << endl << "1 - NEW GAME" << endl;
	cout << "0 - EXIT" << "\n>";
	cin >> game;
	
		if (game == 1)
		{
			system("cls");
			Bank_on_bones(money);
		}
		else if (game < 0 || game > 1)
		{
			cout << "This menu item does not exist" << "\n\n";
			system("pause");
		}
}

void Bank_on_bones(int money)
{
	srand(time(0));

	int cont;
	const int size = 3;
	int arr[size];
	int pc_money = 10;
	int milisecond = 2000;
	int user_bet, pc_bet = 0, user_coin = 0, pc_coin = 0;

	while (true)
	{
		cout << " ______                                                      ______" << endl;
		cout << "|  __  |                       __    __                     |  __  |" << endl;
		cout << "| |__| |                      |  | /  /                     | |__| |                     _____  ______" << endl;
		cout << "|  __  /  ______    ___    __ |  |/  /   ______  ___    __  |  ___ /  ______  ___    __ |  __ ||   ___|" << endl;
		cout << "| |  | \\ |  __  |  |    \\ |  ||     \\   |  __  ||    \\ |  | | |  | \\ |  __  ||    \\ |  ||  ___||___" << endl;
		cout << "| |__|  || |__|  \\ |  |\\ \\|  ||  |\\  \\  | |__| ||  |\\ \\|  | | |__|  || |__| ||  |\\ \\|  || |___  ___|  |" << endl;
		cout << "|_______||______| \\|__| \\____||__| \\__\\ |______||__| \\____| |_______||______||__| \\____||_____||______|" << endl;

		if (money > 0)
		{
			if (pc_money > 0)
			{
				cout << endl << "Your balance: " << money;
				cout << "\t" << "PC balance: " << pc_money << "\n\n";
				cout << "Make your bet from 1 to 6:\n>";
				cin >> user_bet;
				if (user_bet <= money && user_bet > 0 && user_bet < 7)
				{
					pc_bet = rand() % 6 + 1;
					//if (pc_money > 0) pc_bet = rand() % 6 + 1;
					while (true)
					{
						if (pc_bet > pc_money)
							pc_bet = rand() % 6 + 1;
						else break;
					}
					system("cls");
					cout << endl;

					cout << "    (_)  " << endl;
					cout << "   /_ _\\" << endl;
					cout << "    | |" << endl;

					cout << "You bet: " << user_bet << endl;

					cout << "   _____ " << endl;
					cout << "  |     |" << endl;
					cout << "  |_____|" << endl;
					cout << " /_______\\"<< endl;

					cout << " PC bet: " << pc_bet << "\n\n";

					for (int i = 0; i < size; i++)
					{
						arr[i] = rand() % 6 + 1;
						Sleep(milisecond);
						if (arr[i] == 1)
						{
							cout << "  ____________" << endl;
							cout << " /__________ /|" << endl;
							cout << "|           | |" << endl;
							cout << "|           | |" << endl;
							cout << "|     *     | |" << endl;
							cout << "|           | |" << endl;
							cout << "|___________|/" << endl;
						}
						else if (arr[i] == 2)
						{
							cout << "  ____________" << endl;
							cout << " /__________ /|" << endl;
							cout << "|           | |" << endl;
							cout << "|   *       | |" << endl;
							cout << "|           | |" << endl;
							cout << "|       *   | |" << endl;
							cout << "|___________|/" << endl;
						}
						else if (arr[i] == 3)
						{
							cout << "  ____________" << endl;
							cout << " /__________ /|" << endl;
							cout << "|           | |" << endl;
							cout << "|   *       | |" << endl;
							cout << "|     *     | |" << endl;
							cout << "|       *   | |" << endl;
							cout << "|___________|/" << endl;
						}
						else if (arr[i] == 4)
						{
							cout << "  ____________" << endl;
							cout << " /__________ /|" << endl;
							cout << "|           | |" << endl;
							cout << "|  *     *  | |" << endl;
							cout << "|           | |" << endl;
							cout << "|  *     *  | |" << endl;
							cout << "|___________|/" << endl;
						}
						else if (arr[i] == 5)
						{
							cout << "  ____________" << endl;
							cout << " /__________ /|" << endl;
							cout << "|           | |" << endl;
							cout << "|  *     *  | |" << endl;
							cout << "|     *     | |" << endl;
							cout << "|  *     *  | |" << endl;
							cout << "|___________|/" << endl;
						}
						else if (arr[i] == 6)
						{
							cout << "  ____________" << endl;
							cout << " /__________ /|" << endl;
							cout << "|           | |" << endl;
							cout << "|  *     *  | |" << endl;
							cout << "|  *     *  | |" << endl;
							cout << "|  *     *  | |" << endl;
							cout << "|___________|/" << endl;
						}
						if (arr[i] == user_bet) user_coin++;
						if (arr[i] == pc_bet) pc_coin++;
					}
					//user
					if (user_coin == 0) money -= user_bet;
					else if (user_coin == 1) money += user_bet;
					else if (user_coin == 2) money += user_bet * 2;
					else if (user_coin == 3) money += user_bet * 3;
					//PC
					if (pc_coin == 0) pc_money -= pc_bet;
					else if (pc_coin == 1) pc_money += pc_bet;
					else if (pc_coin == 2) pc_money += pc_bet * 2;
					else if (pc_coin == 3) pc_money += pc_bet * 3;

					cout << "\n\n";

					if (money > 0 && pc_money <= 0)
					{
						system("cls");
						system("color 0A");
						cout << "\n\n-=-=-=-=-=-=-=-= Congratulations, you won! =-=-=-=-=-=-=-=-";
						cout << "\n\n" << "NEW GAME? ( 1 - Yes / 0 - No )\n>";
						cin >> cont;
						if (cont == 1)
						{
							user_coin = 0;
							pc_coin = 0;
							money = 10;
							pc_money = 10;
							system("cls");
						}
						else
							break;
					}
					else if (pc_money > 0 && money <= 0)
					{
						system("cls");
						system("color 0C");
						cout << "\n\nYou lose. GAME OVER :-(";
						cout << "\n\n" << "NEW GAME? ( 1 - Yes / 0 - No )\n>";
						cin >> cont;
						if (cont == 1)
						{
							user_coin = 0;
							pc_coin = 0;
							money = 10;
							pc_money = 10;
							system("cls");
							system("color 0E");
						}
						else
							break;
					}
					else
					{ 
						cout << "You have " << user_coin << " mathes. Your balance: " << money << endl;
						cout << "Considance in pc " << pc_coin << ". PC balance: " << pc_money;

						cout << "\n\n" << "Continue ...? ( 1 - Yes / 0 - No )\n>";
						cin >> cont;
						if (cont == 1)
						{
							user_coin = 0;
							pc_coin = 0;
							system("cls");
							system("color 0E");
						}
						else
							break;
					}
				}
				else
				{
					cout << "\n\nYou do not have enough money for such a bet\nor you entered a number not from 1 to 6\n\n";
					system("pause");
					system("cls");
				}
			}
			else
			{
				system("cls");
				system("color 0A");
				cout << "\n\n-=-=-=-=-=-=-=-=Congratulations, you won!-=-=-=-=-=-=-=-=";
				cout << "\n\n" << "NEW GAME? ( 1 - Yes / 0 - No )\n>";
				cin >> cont;
				if (cont == 1)
				{
					user_coin = 0;
					pc_coin = 0;
					money = 10;
					pc_money = 10;
					system("cls");
					system("color 0E");
				}
				else
					break;
			}
		}
		else
		{
			cout << "You do not have enough coins to bet. GAME OVER :-(";
			break;
		}
	}
}

