# contactsManager

![alt tag](https://github.com/NyO1/contactsManager/blob/master/app_screenshot.png)

#Technologies:
<ul>
<li><b>ASP.NET, MVC, C#, Razor, jQuery, JavaScript, AJAX, SQL and Bootstrap</b></ul></li>

The idea is to have a database online with all the contacts like a music library, so everyone can login into his own account and manage his contacts.

#Usage:
<ul>
<li><b>The Home Page</b></li>
The home page displays on the top two rows of 3 profile images (contact photo) each.
These contacts are decided by the user to have them really handy. In short words they represent your <b>favorite contacts</b>, and just clicking on one of these will be diplayed the contact details.
After this, we have a <b>search bar</b> and the button that permit to <b>add a new contact</b>.

![alt tag](https://github.com/NyO1/contactsManager/blob/master/Images/searcadd.png)

The search bar permit the user to search into the database any contact by the first name or the last name.
The add button will move the user to a new page with a form where he can fill it with the contacts info that he wants.

![alt tag](https://github.com/NyO1/contactsManager/blob/master/Images/addForm.png)

After the search bar the user can find the list of the contacts that are in the database.
Each one is displayed with the full name (Fist name + last name), the phone number, the email address and two action-buttons.

![alt tag](https://github.com/NyO1/contactsManager/blob/master/Images/tableView.png)

The first action button is the <b>Details</b> button (the light blue one) used to display the full contact details. So the user, on clicking on it, will be send to a new page with all the contact details; in this view we have the possibility tho <b>Modify</b> this contact that we have selected. The user can modify the contact by clicking on the <b>Edit</b> button that's displayed under the contact name.

The other in the contacts table is the <b>Delete</b> button (the red one), on clicking on it the system will diplay a pop-up window to let the user confirm that he wants to delete this contact.

![alt tag](https://github.com/NyO1/contactsManager/blob/master/Images/deletepop.png)



#TODO
<ul>
<li>The autocomple function is not working on the search bar using jQuery</li>
<li>Paging the list of contacts using Autopaging.Mvc already imported</li>
</ul>

<br>
<hr>
Developer: <em>Andrea Schisani</em>


