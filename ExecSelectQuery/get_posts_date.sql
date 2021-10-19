select concat(a.first_name, " ", a.last_name) as name, p.date from  authors as a
join posts as p on a.id = p.author_id
order by name
