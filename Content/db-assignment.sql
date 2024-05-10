-- Users

Users
- Id guid PK
- name varchar notnull
- email varchar notnull

Topics
- Id GUID PK
- Title varchar notnull

Messages
- Id GUID PK
- topic_id FK(topics.Id) cascade delete/update nothing
- user_id FK(users.id)  cascade delete/update nothing 
- text varchar(255/MAX)


select 
    t.id, 
    count(msg.id) 
    from Messages msg
        inner join topic t on msg.topic_id = t.id
    group by t.Id
    order by count(msg.id) DESC
    LIMIT 3


// This works but not preferable, hard to support
// should be splittint on getting id, and select Users data(more than one table)
select * from Users
 where user_id = (
        select msg.user_id 
        from msg 
            inner join topics t on 
         where t.Title = "football"
         group by msg.user_id 
         order by count(msg.id) DESC
         limit 1)

//CTE
with maxTops as(
        select msg.user_id 
        from msg 
            inner join topics t on 
         where t.Title = "football"
         group by msg.user_id 
         order by count(msg.id) DESC
         limit 1)  
  select * from Users where Users = maxTop.id       


