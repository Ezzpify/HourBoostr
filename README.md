# HourBoostr
Boosting Steam account hours

This will allow you to boost the hours played of multiple Steam games on multiple accounts at the same time, without even having steam open!.

Run HourBoostr then set up the Settings.json file to include the accounts you want to use, and which games you want to boost.
Enter your password in the console for each account and the email code if required, then you can just leave it running on whatever server/computer you want!

While HourBoostr is running, neither of your Steam accounts will appear online on Steam, but they will still get their game hours boosted, and they will still recieve card drops.

You find the game IDs by going to the specific game you want to boost via the browser.
(You can also go via your Games page under your profile on Steam)
http://steamcommunity.com/app/730

Program:

![dec1wuy 1](https://cloud.githubusercontent.com/assets/9034691/9148090/38f3d256-3d72-11e5-9a59-bbc8f7929c7e.png)

Drops:

![p9qnjoz 1](https://cloud.githubusercontent.com/assets/9034691/9141437/f8cd14be-3d38-11e5-9d09-52692fd156eb.png)

Example image:

![enyo9tw 1](https://cloud.githubusercontent.com/assets/9034691/9140843/68b653d0-3d34-11e5-8121-dcc882fa70fe.png)

JsonHelper for those who are having problems with json syntax:

![swagster](https://cloud.githubusercontent.com/assets/9034691/9156867/e5b60ae6-3ee8-11e5-87ba-83714aef916e.gif)

Type each game ID under games that you want to boost like this:
Example Settings.json setup
```json
{
  "Account": [
    {
      "Username": "acc1",
      "Games": [
        730,
        271590,
        252950
      ]
    },
	{
      "Username": "acc2",
      "Games": [
        730,
        10
      ]
    },
	{
      "Username": "acc3",
      "Games": [
        730
      ]
    }
  ]
}
```
