# Cybersecurity Awareness Bot - Part 2

## Student Details

Name: Onga Ntuntu  
Module: PROG6211  
Project: Cybersecurity Awareness Chatbot  
Part: Part 2 - GUI Interface, Dynamic Responses, Sentiment Detection, and Memory  

---

## Project Description

This project is a Cybersecurity Awareness Chatbot created using C# and Windows Forms in Visual Studio 2022.

The chatbot helps users learn about online safety and cybersecurity topics such as password safety, phishing, scams, privacy, malware, social engineering, and safe browsing.

For Part 2, the chatbot was upgraded from a console application into a graphical user interface. The GUI allows the user to type messages and receive chatbot responses in a more user-friendly way.

---

## Features

- Windows Forms GUI
- Voice greeting when the app starts
- Cybersecurity ASCII art
- Chat display area
- User input box
- Send button
- Keyword recognition
- Random cybersecurity responses
- Memory and recall
- Sentiment detection
- Conversation flow
- Error handling
- Organised code using classes and services

---

## Cybersecurity Topics

The chatbot can respond to:

- Password safety
- Phishing
- Online scams
- Privacy
- Malware
- Social engineering
- Safe browsing

---

## Example Questions

You can ask the chatbot:

My name is Onga

How are you?

What is your purpose?

What can I ask you about?

Tell me about password safety

Give me a phishing tip

I am worried about online scams

Tell me more

I am interested in privacy

What is my favourite topic?

What is my name?

---

## Project Structure

CyberSecurityAwarenessBotGUI2

Assets
- ascii.txt
- greeting.wav

Models
- UserMemory.cs

Services
- AudioService.cs
- ChatBotService.cs
- SentimentService.cs

MainForm.cs  
MainForm.Designer.cs  
Program.cs  
App.config  
CyberSecurityAwarenessBotGUI2.csproj  

---

## File Descriptions

Program.cs starts the application.

MainForm.cs controls the Windows Forms GUI, including the chat box, input box, send button, title, colours, and ASCII art.

UserMemory.cs stores the user's name, favourite cybersecurity topic, and last topic discussed.

ChatBotService.cs handles the chatbot responses, keyword recognition, random tips, memory recall, and conversation flow.

SentimentService.cs detects simple emotions such as worried, curious, and frustrated.

AudioService.cs plays the voice greeting from the Assets folder.

The Assets folder stores the greeting.wav audio file and ascii.txt file.

---

## How to Run the Project

1. Download or clone the GitHub repository.
2. Open the solution file in Visual Studio 2022.
3. Make sure the Assets folder contains:
   - ascii.txt
   - greeting.wav
4. Build the project.
5. Press F5 or click Start to run the chatbot.

---

## Audio File Note

The voice greeting must be named exactly:

greeting.wav

It must be inside the Assets folder.

The file should be set to:

Build Action: Content  
Copy to Output Directory: Copy if newer  

---

## Memory Feature

The chatbot can remember the user's name.

Example:

User: My name is Onga  
Bot: Nice to meet you, Onga.

The chatbot can also remember the user's favourite cybersecurity topic.

Example:

User: I am interested in privacy  
Bot: Great! I’ll remember that you are interested in privacy.

---

## Sentiment Detection

The chatbot detects simple emotions and responds in a supportive way.

Examples:

User: I am worried about online scams  
User: I am curious about phishing  
User: I am frustrated with passwords  

The chatbot then gives a helpful cybersecurity response based on the topic.

---

## Conversation Flow

The chatbot can continue the current topic when the user types:

Tell me more  
Explain more  
Another tip  

This makes the conversation feel more natural.

---

## Error Handling

If the user enters an empty message, the chatbot asks the user to type something.

If the chatbot does not understand the message, it gives a default response and asks the user to rephrase.

---

## GitHub Requirements

This project is uploaded to GitHub and includes:

- Complete source code
- Assets folder
- README file
- Visual Studio project files
- Meaningful commits
- Releases and tags

---

## Video Presentation

YouTube video link:

ADD YOUR VIDEO LINK HERE

---

## Reference

Pieterse, H. 2021. The Cyber Threat Landscape in South Africa: A 10-Year Review. The African Journal of Information and Communication, 28(28). Available at: https://www.scielo.org.za/scielo.php?pid=S2077-72132021000200003&script=sci_arttext [Accessed 16 February 2026].

---

## Conclusion

This Part 2 project successfully upgrades the Cybersecurity Awareness Bot from a console application into a Windows Forms GUI application. It includes voice greeting, ASCII art, keyword recognition, random responses, memory, sentiment detection, conversation flow, and error handling.
