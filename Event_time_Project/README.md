This project development by Ayaulym Myrzabayeva 

Name
My project Name is Event Time Project(Management)

Introduction
This tutorial explains the steps required for an interactive event calendar, in ASP.NET the MVC application. We will be using dhtmlxScheduler in the future, an open source JavaScript calendar that provides an event scheduling interface with drag-and-drop capabilities and support for AJAX,and JQUery . Events can be displayed as a day/week/month/year and edited by the end user on the client side.

**Calendars**
A calendar is a collection of related events, along with additional metadata such as summary, default time zone, location, etc. Each calendar is identified by an ID which is an email address. Calendars can have multiple owners.

**Events**
An event is an object associated with a specific date or time range. Events are identified by an ID that is unique within a calendar. Besides a start and end date-time, events contain other data such as summary, description, location, status, reminders, attachments, etc.


Description
My project is like a calendar , we can add More precisely the user. Write in the calendar of events and tasks that he / she should do.
My project has an admin and user part. The admin part is more precisely the admin can add (tasks and events if specifically he can add all functions) and the user part which can add all functions as well as the admin.
The peculiarity of my project is to improve a person's life and so that people do not forget what they need and when to submit their work and write everything in the calendar.

   C# code Snippet
```c#
[HttpPost]
public JsonResult SaveEvent(Event e)
{
    var status = false;
    using (MyDatabaseEntities dc = new MyDatabaseEntities())
    {
        if (e.EventID > 0)
        {
            //Update the event
            var v = dc.Events.Where(a => a.EventID == e.EventID).FirstOrDefault();
            if (v != null)
            {
                v.Subject = e.Subject;
                v.Start = e.Start;
                v.End = e.End;
                v.Description = e.Description;
                v.IsFullDay = e.IsFullDay;
                v.ThemeColor = e.ThemeColor;
            }
        }
        else
        {
            dc.Events.Add(e);
        }
        dc.SaveChanges();
        status = true;
    }
    return new JsonResult { Data = new { status = status } };
}


**Images**
Sample Photo:
![Image](https://cdn.syncfusion.com/visual-studio-market/xamarin/scheduler/scheduler.png) => I will make it so that a person can see their calendar anywhere as long as there was an Internet connection. 
![Image](https://printcalendarpage.com/wp-content/uploads/2020/03/unnamed-file-1073.jpg)


**Improve the Project**
=> In the project, the user can manage their own tasks. Which stores information in a database, and there we can configure access rights to your calendar (so that if you need, only one user can make changes to it).
=> I will improve the admin and user parts. Add a calendar and separate the admin and user roles so that the user can add a specific part. And I will make a progress bar so that the user can see how much they have completed their project or their task.

Authors and acknowledgment
Myrzabayeva Ayaulym worked in the project

License
The project is available as open source under the terms of the License.This article, along with any associated source code and files, is licensed under The GNU General Public License
Project status
If you have run out of energy or time for your project, put a note at the top of the README saying that development has slowed down or stopped completely. Someone may choose to fork your project or volunteer to step in as a maintainer or owner, allowing your project to keep going. You can also make an explicit request for maintainers.
