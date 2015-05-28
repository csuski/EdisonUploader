Edison Uploader
=============

This is a quick C# program designed to allow someone to easily upload
a *.elf file through SSH to their Intel Edison and start running the
Arduino sketch.

Usage
=============

1. Run the program
2. Add in your host, username and password for your Intel Edison (optionally save this info).
3. Test the connection, if it doesn't work check the settings and fix
4. Set your watch, the default file should be where the Arduino files are compiled to
5. In Arduino create your sketch and hit verify so it compiles.
6. The Edison Uploader should detect that the new file after it is compiled and pop up a message box, click yes to automatically fill in this file name.
7. Press Upload ELF to upload the file to your Intel Edison. 

It should automatically start running the sketch!




