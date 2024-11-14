# OllamaBlazorApp

## Overview
OllamaBlazorApp is a Blazor server application that integrates with the Ollama AI API using a custom `OllamaClient`. It includes a `Logger` class for performance logging and chat history management, with a user-friendly chat interface enhanced by Bootstrap icons and custom styles.

## Features
- Integrates with the Ollama AI API.
- Custom `OllamaClient` for API communication.
- `Logger` class for logging and chat history.
- User-friendly chat interface with Bootstrap icons.
- Custom CSS styling for input and buttons.

## Installation
1. Clone the repository.
2. Open the project in Visual Studio 2022.
3. Restore NuGet packages.
4. Run the project.

## Usage
1. Navigate to the `/chat` page.
2. Enter your message and click **Send**.
3. View the conversation history and interact with Ollama.

## File Structure
- **wwwroot**: Contains static files (CSS, JS).
  - `css/site.css`: Custom styles.
- **Pages**: Razor components (e.g., `Chat.razor`).
- **Data**: Services (e.g., `WeatherForecastService.cs`).
- **Shared**: Shared UI components.
  - `MainLayout.razor`: Main layout.
  - `NavMenu.razor`: Navigation menu.
- **OllamaBlazorApp**: Core functionality.
  - `Logger.cs`: Handles logging and chat history.
  - `OllamaClient.cs`: Manages API interactions.

## License
This project is licensed under the MIT License.
