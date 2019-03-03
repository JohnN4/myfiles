select* from officer;
select*from product;

select p.Name Product, t.Name Type 
from product p join product_type t using(product_type_cd);

select b.branch_id, b.name, b.city,e.assigned_branch_id, e.last_name,e.title
from branch b join employee e on b.branch_id=e.assigned_branch_id;

select e.last_name 'Employee Name', e.title 'Employee Title', m.last_name 'Manager Name', m.title 'Manager Title' from employee e left join employee m on e.superior_emp_id=m.emp_id;

select p.Name, a.avail_balance, c.cust_id, i.last_name
from PRODUCT p, ACCOUNT a, CUSTOMER c, INDIVIDUAL i 
join PRODUCT , ACCOUNT , CUSTOMER, INDIVIDUAL where c.CUST_ID= I.CUST_ID;

select p.name, a. avail_balance, ifnull(i.last_name, o.last_name)'Last Name' from account a join product p on a.product_cd=p.product_cd
left join individual i on a.cust_id=i.cust_id left join officer o on a.cust_id=o.cust_id;
