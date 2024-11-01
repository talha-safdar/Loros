THANK YOU FOR PURCHASE
ALL LINES IN SCRIPTS FILES IS COMMENTED


//----------------------------------------------------------------------------------------------------------------------------
FOR ADD NEW ITEM IN SCROLL SHOP:

-GO TO HIERARCHY IN SCENE, GO TO "Canvas\Panel\Scroll snap\Container\Page1" AND LOOK COMPONENT "Shop.cs" INSPECTOR. 
LOOK VAIRABLE "List" IN INSPECTOR FOR SHOW ALL PACKS. PS : ONE PACK CONTAINS THREE OFFERS.
CREATE YOUR PACK HERE WITH THREE OFFERS. CHOOSE NAME, PRICE, TYPE CURRENCY OF PURCHASE, AMOUNT, IMAGES AND PURCHASE CURRENCY.
SAME FOR TODAY'S DEAL IN LIST WITH THE VARIABLE "OFFER DAY" 
PACK_SHOP PREFAB IS IN "ASSET\UI_MOBILE_GAME\PREFABS", IS AUTOMATICALLY INSTANTIATE IN "Shop.cs" LINE 54 IN BOUCLE "for".
OFFER_DAY PREFAB IS IN "ASSET\UI_MOBILE_GAME\PREFABS", IS AUTOMATICALLY INSTANTIATE IN "Shop.cs" LINE 45 IN BOUCLE "for".

PS : When you want to make a purchase and click on a pack, the window titled "Windows_Shop_opacity" appears with all the 
details of the purchase. The function to make the window appear called "Windows_Shop_opacity" is in the line 82 "Shop.cs". 
The prefab is in the hierarchy "Canvas\Panel\Windows_Shop_opacity".

PS : When you click the button to buy (in hierarchy "Canvas\Panel\Windows_Shop_opacity\Bg1\Bg2\Btn_buy"), it launches 
the function "PopMoney" in "GlobalManager.cs" at line 40.




//----------------------------------------------------------------------------------------------------------------------------
FOR ADD NEW TEAM IN SCROLL TEAM:

-GO TO HIERARCHY IN SCENE, GO TO "Canvas\Panel\Scroll snap\Container\Page2" AND LOOK COMPONENT "Viewteam.cs" INSPECTOR. 
LOOK VAIRABLE "Teamlist" IN INSPECTOR FOR SHOW ALL TEAMS.
CREATE YOUR TEAM. CHOOSE NAME, NUMBER MEMBER, NUMBER TROPHY, IS CLOSED OR NOT, IMAGES FLAG AND COUNTRY.
TEAM PREBAF IS IN "ASSET\UI_MOBILE_GAME\PREFABS", IS AUTOMATICALLY INSTANTIATE IN "Viewteam.cs" LINE 33 IN BOUCLE "for".

PS : When you want to inspect a team and click on it, the window titled "Windows_Team_opacity" appears with all the details 
of the chosen team.  The function to make the window appear called "Windows_Team_opacity" is in the line 49 "Viewteam.cs". 
The prefab is in hierarchy "Canvas\Panel\Windows_Team_opacity".




//----------------------------------------------------------------------------------------------------------------------------
PAGES SCROLL:

The pages are controlled by horizontal Scrollview. They are in hierarchy "Canvas\Panel\Scroll snap\Container".
Scrollview component is in "Canvas\Panel\Scroll snap", look "ScrollRectEx.cs" component.
The component "ScrollSnapRect.cs" handles sweeps and speed.
Open script for look all lines commented.





//----------------------------------------------------------------------------------------------------------------------------
FOR ADD NEW PAGE:

PS : When you create a new page, you must also create a new bottom selection button.

-FOR ADD NEW PAGE IS EASY, JUST GO TO "Canvas\Panel\Scroll snap\Container" IN HIERARCHY AND DUPLICATE THE LAST EXISTING PAGE WITH 
"RIGHT CLICK MOUSE AND SELECT DUPLICATE" AND EDIT ALL IMAGE IN NEW PAGE

-FOR ADD NEW BOTTOM BUTTON SELECTION PAGE, JUST GO TO "Canvas\Panel\Button_Page_Selection" IN HIERARCHY AND DUPLICATE THE LAST EXISTING 
BOTTOM BUTTON WITH "RIGHT CLICK MOUSE AND SELECT DUPLICATE".

PS : The buttons at the bottom of the page selection are assigned according to their position in the hierarchy. For example, 
the button in 3rd position, will be the selection button of the 3rd page and so on. So if you are creating a new page, do not
forget to create a new bottom page selection button by duplicating the last existing button. The same goes for creating a new
page, select the last existing page and duplicate there.





//----------------------------------------------------------------------------------------------------------------------------
FOR MODEL 3D ISLAND
- Created on Cinema 4d R17
- Geometry Polygonal
- Polygons 4,868
- Vertices 4,730
- Procedural Textured





Cordially
For Help => paradox.ultimate@hotmail.fr
Web Site => http://www.ricl-chatland.fr
