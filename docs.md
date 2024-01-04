## PRODUCTS

### create
POST /wp-json/wc/v3/products
return PRODUCT

### update
PUT /wp-json/wc/v3/products/<id>
return PRODUCT

### get
GET /wp-json/wc/v3/products/<id>
return PRODUCT

### get all
GET /wp-json/wc/v3/products
return PRODUCT[]

### delete
DELETE /wp-json/wc/v3/products/<id>
return PRODUCT


### update batch
POST /wp-json/wc/v3/products/batch
return create[] PRODUCT[]
	   update[] PRODUCT[]
	   delete[] PRODUCT[]




## PRODUCT VARIATIONS