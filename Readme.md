# Unity Twitch Stream Tools

This repo holds the development of an interactive stream overlay/chatbot/alerts/whatever for my twitch channel (And hopefully yours in a near future). It aims to be an extensible base for other devs who want an custom extensible tool in (unity/c#)

Most of its developement will be done on streaming at <a href="https://www.twitch.tv/sigr3s" target="_blank"> my twitch channel</a>. Also, feel free to request whatever feature you will love to see in this project and I will do my best to fit it at the correct time.

## Current status

Currently there is not much done: only the chat showing up the messages and the basic setup for the chtabot. 

For these two parts there is a scene to configure the targeted channel and a second one for the overlay (you only need to configure the targeted channel once). To get the chat working you need a bot twitch account and create a config.json in the streaming assets folder with the following format:

    {
        "bot_name" : "your_bot_name",
        "bot_access_token" : "bot_access_token",
        "bot_refresh_token" : "bot_refresh_token"
    }

### Screenshots

![Captura](https://i.imgur.com/UVr82e2.png)

![main](https://i.imgur.com/tslACZ5.png)



## Dependencies

- <a href="https://github.com/keijiro/KlakNDI" target="_blank"> Keijiro - NDI Sender</a>
- <a href="https://github.com/TwitchLib/TwitchLib.Unity" target="_blank"> TwitchLib</a> 

## System requirements

- Currently is only working on windows (will try to add macosx support asap)
- Unity 2018.2
- Obs studio with ndi plugin (https://github.com/Palakis/obs-ndi/releases/tag/4.5.2)

## TODO / Future work

- Viewer presence in bottom panel
- Update last follower/subscriber
- Alerts
- Chatbot to answer simple commans


## License

Copyright (C) 2018 Sergi Tortosa

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
