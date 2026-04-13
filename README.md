# PROG_POE
#screenshot<img width="1366" height="768" alt="Screenshotwork" src="https://github.com/user-attachments/assets/e8ad0662-b754-4011-a15e-2fe0715fc3d6" />
Cybersecurity Awareness Chatbot (A.J)

Overview

The Cybersecurity Awareness Chatbot (A.J) is a C# console application designed to educate users about online safety. It provides simple, interactive guidance on topics like passwords, phishing, and safe browsing.

This chatbot aims to help users make safer decisions while using the internet.



Features
	•	Interactive console-based chatbot
	•	ASCII logo display from an image
	•	Audio greeting using a .wav file
	•	Simulated typing effect for responses
	•	Basic keyword-based responses for:
	•	Password security
	•	Phishing awareness
	•	Safe browsing
	•	General cybersecurity tips



Technologies Used
	•	C#
	•	.NET Framework 4.7.2
	•	System.Media (for audio playback)
	•	System.Drawing (for ASCII image rendering)



How to Run the Project

1. Clone the repository

git clone https://github.com/thatokhotsomofikwe/PROG_POE

2. Open in Visual Studio
	•	Open the .sln file in Visual Studio 2022

3. Ensure assets are set correctly

Make sure the following files exist:

Assets/logo.jpg
Assets/greet.wav

Then in Visual Studio:
	•	Right-click each file → Properties
	•	Set Copy to Output Directory → Copy if newer

4. Run the application
	•	Press F5 or click Start



How to Use
	•	Enter your name when prompted
	•	Ask questions like:
	•	“What is phishing?”
	•	“How do I create a strong password?”
	•	“How can I browse safely?”
	•	Type exit, quit, or bye to end the session



Example Interaction

Please enter your name: John

Hello, John! I'm A.J.

John: what is phishing
Bot: Phishing messages often pressure you to act quickly or click suspicious links...



CI

This project uses GitHub Actions for Continuous Integration.

The workflow:
	•	Restores dependencies
	•	Checks code formatting
	•	Builds the project

Future Improvements
More advanced natural language processing
GUI version (Windows Forms or WPF)
