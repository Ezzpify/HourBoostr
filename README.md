# HourBoostr
Boosting Steam account hours

This will allow you to boost the hours of multiple Steam games on multiple accounts with no restrictions.
Run HourBoostr then set-up the Settings.json file.

Want to sell an hourboosting service? Want to sell cool accounts with many hours? Or simply want to boost your own account? Well, HourBoostr is the way to go!

When you're boosting your account will appear offline, but the hours will get boosted. :+1: 

You find the game IDs by going to the specific game you want to boost via the browser.
(You can also go via your Games page under your profile on Steam)
http://steamcommunity.com/app/730 (730 being the game ID)

Set up all the accounts in the settings.json file then run HourBoostr.
Enter your password for each account and email code if required, then you can just leave it running on whatever server/computer you want!

If you're cautious about entering your password, check out the source code and compile it for yourself!
HourBoostr is written in C# with help from SteamKit2 - check out the source code!

![hourhoostr](https://cloud.githubusercontent.com/assets/9034691/9138015/c4ec5fea-3d21-11e5-858a-f7fc1aae15df.gif)

Drops:

![p9qnjoz 1](https://cloud.githubusercontent.com/assets/9034691/9141437/f8cd14be-3d38-11e5-9d09-52692fd156eb.png)


Example image:

![enyo9tw 1](https://cloud.githubusercontent.com/assets/9034691/9140843/68b653d0-3d34-11e5-8121-dcc882fa70fe.png)


Type each game ID under games that you want to boost like this:

Example Settings.json setup
```
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
