# KH2FM Editor

Made by: Osdanova

V. 1.0

### Version 1.0 :

First official release of the tool.

If you create and share something made thanks to this tool, crediting is not necessary, but welcome. If you discover what an unknown field is used for, let the community know (Eg: At OpenKH's Discord server)

This tool has been in the making for some time and most of it is not crash-proof (And probably won't be)

Lastly, I have no page for "Can't read this file", so if you double click something and a page doesn't open, the tool doesn't support it.

-----------------------------------------------------------------------------------------------------------------------------

## HOW TO USE

First, you need the extracted ISO.

Open the tool and drag your files in the left panel. You can also drag a folder and a treeview will show.

![](readme1.png)

From here, you can open any supported file by double clicking. The supported files are:

  * 00objentry.bin
  * 00battle.bin
  * 03system.bin
  * mixdata.bar
  * jiminy.bar
  * ARD files
  
![](readme2.png)

Depending on the file, you may be able to directly edit a field (Note that some are non-writable translations of IDs)

You can Test your modifications in-game by using the TEST buttons.

Note that it will write the data on the offset written on "Test Offset". Default values are given on some files for an english patched ISO (Crazycatz's patch) but be warned that some files dinamically load in varying addresses.

You can also Export the modified file using the "Export" button.

NOTE: If you add a record to a table, make sure to click on Save current.

-----------------------------------------------------------------------------------------------------------------------------

## TOOLS

Pretty self explanatory. Use Inventory to edit your inventory and stats to edit your stats.

NOTE: Stats requires you to open the game first or it'll crash.

This is because it reads PCSX2's memory when it's open.

-----------------------------------------------------------------------------------------------------------------------------

## LAST WORDS

Sorry if I forgot something. I'm sure you'll get the hang of it.

Big thanks to the community, specially to the people at OpenKH, who are always a great help.
