# Underprepaired 
Welcome to UnderprePAIRed! We specialize in giving you the yang to your yin. Come along and see if we can help you harmonize your sock drawer or find your lonely mitten's soulmate.

## Claims
We are capturing Full Name, to be displayed when the user logs in. Email is also being captured, to be checked against our email polocy for Founder site priveledge.

## Policies
We are enforcing an email policy to check if users have an @underprepaired.shop email. We are calling these users "Founders". Only users that an email at that domain can access the secret /account/founder page (shh don't tell anyone)

## Deployed website
Visit https://underprepaired.azurewebsites.net

## DB Schema
![](/Underprepaired_DB.jpg)

PRODUCT: Holds all product information for our website and has a one to many relationship with Cart Item
CART: Holds all user carts and has a property for username to associate a cart with a user
CART ITEM: Holds all items that belong in carts, uses product id and cart id to make a composite key and has navigation properties for both

## Vulnerability Report
[Vulnerability Report](/vulnerability-report.md)

## Contributors
Aaron Frank & Richard Jimenez
