#include <stdlib.h>
#include <string.h>
#include <stdio.h>
#include <assert.h>
#include "sqlite3.h"

enum Arguments { Unknow = 0, Db = 1 } argument;



void openDb(wchar_t *dbPath)
{
	sqlite3 *db;
	int result = sqlite3_open(dbPath, &db);
	if (SQLITE_OK != result)
	{
		printf("Opening %s failed!\n", dbPath);
		sqlite3_close(db);
	}

	printf("Connected to %s\n", dbPath);
	sqlite3_close(db);
}



#if SQLITE_SHELL_IS_UTF8
int SQLITE_CDECL main(int argc, char **argv) {
#else
int SQLITE_CDECL wmain(int argc, wchar_t **wargv) {
	char **argv;
#endif

	sqlite3_initialize();
	argv = sqlite3_malloc64(sizeof(argv[0])*argc);
	if (0 == argv)
	{
		exit(1);
	}

	argument = Unknow;
	for (int i = 0; i < argc; i++)
	{
		argv[i] = sqlite3_win32_unicode_to_utf8(wargv[i]);
		if (0 == strcmp("--db", argv[i]))
		{
			argument = Db;
		}
		else
		{
			switch (argument)
			{
			case Db:
				openDb(argv[i]);
				break;

			default:
				break;
			}

			// Reset the argument type
			argument = Unknow;
		}
	}

	sqlite3_free(argv);
	sqlite3_shutdown();

	system("PAUSE");
	exit(0);
}