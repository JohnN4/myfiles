-- Write a query to display the name, product line, and buy price of all products. 
-- The output columns should display as “Name”, “Product Line”, and “Buy Price”. The output should display the most expensive items first.

select productName 'Name', productline 'Product Line', buyPrice 'Buy Price' from products;

 -- Write a query to display the first name, last name, and city for all customers from Germany. Columns should display as “First Name”, 
 -- “Last Name”, and “City”. The output should be sorted by the customer’s last name (ascending).

select contactFirstName 'First Name', contactLastName 'Last Name', city 'City' from customers 
where country='Germany' order by contactLastName asc;

-- Write a query to display each of the unique values of the status field in the orders table. 
-- The output should be sorted alphabetically increasing. Hint: the output should show exactly 6 rows.

select distinct status from orders order by status asc ;

-- Select all fields from the payments table for payments made on or after 
-- January 1, 2005. Output should be sorted by increasing payment date.

select paymentDate  
from payments 
where paymentDate>='2005-1-1';

-- Write a query to display all Last Name, First Name, Email and Job Title of all employees working
 -- out of the San Francisco office. Output should be sorted by last name.

select e.lastName 'Last Name', e.firstName 'First Name', e.email 'Email', e.jobTitle 'Job Title'
 from employees e
join Offices o on  o.city = 'San Francisco' order by lastName asc;

-- Write a query to display the Name, Product Line, Scale, and Vendor of all of the car products – both classic and vintage. 
-- The output should display all vintage cars first (sorted alphabetically by name), and all classic cars last 
-- (also sorted alphabetically by name).

select productName 'Name', productline 'Product Line', productScale 'Scale', productVendor 'Vendor' from products
where ProductLine in ('Classic Cars', 'Vintage Cars')
order by ProductLine desc, productVendor asc;

-------------------------------------------------------------------------------------------
-- Write a query to display each customer’s name (as “Customer Name”) alongside the name of the employee who is responsible 
-- for that customer’s orders. The employee name should be in a single “Sales Rep” column formatted as “lastName, firstName”. 
-- The output should be sorted alphabetically by customer name.

select  c.customerName '"Customer Name"', concat(e.lastName,',', e.firstName) '"Sales Rep"'
 from customers c  join employees e on c.salesRepEmployeeNumber = e.employeeNumber
 order by customerName asc;
 
 -- Determine which products are most popular with our customers. For each product, list the total quantity ordered along with the total 
 -- sale generated (total quantity ordered * priceEach) for that product. The column headers should be “Product Name”, 
 -- “Total # Ordered” and “Total Sale”. List the products by Total Sale descending.
 
 select p.productName 'Product Name', sum(o.quantityOrdered) 'Total#Ordered', sum(o.quantityOrdered * o.priceEach) 'Total Sale' 
 from products p
 join orderdetails o on p.productCode = o.productCode 
 group by p.productCode order by 'Total Sale' desc;
 
 -- Write a query which lists order status and the # of orders with that status. 
 -- Column headers should be “Order Status” and “# Orders”. Sort alphabetically by status.
 
 select status 'Order Status',  orderNumber '# Order' 
 from orders order by status asc;
 
 -- Write a query to list, for each product line, the total # of products sold from that product line. 
 -- The first column should be “Product Line” and the second should be “# Sold”. Order by the second column descending.
 
 select p.productLine 'Product Line', sum(o.quantityOrdered) '# Sold' 
 from products p 
 join orderdetails o on p.productCode = o.productCode 
 group by productline 
 order by quantityOrdered desc;
 
  -- For each employee who represents customers, output the total # of orders that employee’s customers have placed alongside 
  -- the total sale amount of those orders. The employee name should be output as a single column named “Sales Rep” formatted 
  -- as “lastName, firstName”. The second column should be titled “# Orders” and the third should be “Total Sales”. Sort the output 
  -- by Total Sales descending. Only (and all) employees with the job title ‘Sales Rep’ should be included in the output, and if the 
  -- employee made no sales the Total Sales should display as “0.00”.
 
select concat(e.lastname,',',e.firstName) as 'Sales Rep',
ifnull(quantityOrdered, 0.00) as '# Orders', ifnull(sum(quantityOrdered*priceEach), 0.00) as 'Total Sales'
from employees as e left join customers as c on e.employeeNumber = c.salesRepEmployeeNumber
left join orders as o using(customerNumber)
left join orderdetails as od using(orderNumber)
where jobTitle = 'Sales Rep'
group by employeeNumber
order by 3 desc;

-- Your product team is requesting data to help them create a bar-chart of monthly sales since the company’s inception. 
-- Write a query to output the month (January, February, etc.), 4-digit year, and total sales for that month. 
-- The first column should be labeled ‘Month’, the second ‘Year’, and the third should be ‘Payments Received’. 
-- Values in the third column should be formatted as numbers with two decimals – for example: 694,292.68.

select monthname(paymentDate) as 'Month', extract(year from paymentdate) as 'Year', sum(amount) as 'Payment Received'
from payments
group by  monthname(paymentDate), extract(year from paymentdate)
order by extract(year from paymentdate) asc;
 
 

 
