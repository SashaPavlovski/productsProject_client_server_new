import React, { useContext } from "react";

import { Link } from "react-router-dom";
import { deleteProductAsync } from "./../servers/servers.components";

export const ProductContainer = ({
  btnLink,
  productObject,
  changeSetfunction,
}) => {
  let { ProductName, UnitPrice, ProductID } = productObject;

  const deleteProduct = async (id) => {
    await deleteProductAsync(id);
  };

  return (
    <>
      <Link
        onClick={() => btnLink(productObject)}
        to={`/ProductData${ProductID}`}
      >
        <h2>{ProductName}</h2>
        <div>unitPrice : {UnitPrice.Value}</div>
        <div>productID : {ProductID}</div>
      </Link>
      <button
        className="btn btn-primary"
        onClick={() => deleteProduct(ProductID)}
      >
        Delete
      </button>
      <Link
        to="/updatePage"
        className="btn btn-primary"
        onClick={() => {
          changeSetfunction(productObject);
        }}
      >
        Update
      </Link>
    </>
  );
};
