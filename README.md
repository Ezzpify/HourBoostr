# HourBoostr
Boosting Steam account hours

This will allow you to boost the hours played of multiple Steam games on multiple accounts at the same time, without even having steam open!.

Run HourBoostr then set up the Settings.json file to include the accounts you want to use, and which games you want to boost.
Enter your password in the console for each account and the email code if required, then you can just leave it running on whatever server/computer you want!

You find the game IDs by going to the specific game you want to boost via the browser.
(You can also go via your Games page under your profile on Steam)
http://steamcommunity.com/app/730

Drops:
![p9qnjoz 1](https://cloud.githubusercontent.com/assets/9034691/9141437/f8cd14be-3d38-11e5-9d09-52692fd156eb.png)

Example image:
![enyo9tw 1](https://cloud.githubusercontent.com/assets/9034691/9140843/68b653d0-3d34-11e5-8121-dcc882fa70fe.png)

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
