import React, { useState, useContext } from "react";

import { Link } from "react-router-dom";
import { UpdateProductAsync } from "../../components/servers/servers.components.js";
import { UpdateContext } from "./../../context/update.context";

export const UpdatePage = () => {
  const { productUp } = useContext(UpdateContext);
  console.log(productUp.ProductName + "UpdatePage ");
  let { ProductName, ProductID, UnitPrice, UnitInStock } = productUp;
  const [productName, setProductName] = useState("");
  const [unitPrice, setUnitPrice] = useState("");
  const [unitInStock, setUnitInStock] = useState("");

  const handleUpdateChanges = async () => {
    let upDateProduct = {
      ProductName: productName,
      ProductID: ProductID,
      UnitPrice: unitPrice,
      UnitInStock: unitInStock,
    };
    await UpdateProductAsync(upDateProduct);
    <Link to="\">back to the list</Link>;
  };
  return (
    <div>
      <div className="col-md-4">
        <label for="validationCustom01" className="form-label">
          Product Name
        </label>
        <input
          aria-label={ProductName}
          type="text"
          className="form-control"
          id="validationCustom01"
          onChange={(e) => setProductName(e.target.value)}
        />
        <div className="valid-feedback">Looks good!</div>
      </div>
      <div className="col-md-4">
        <label for="validationCustom01" className="form-label">
          Unit Price
        </label>
        <input
          aria-label={UnitPrice}
          type="text"
          className="form-control"
          id="validationCustom01"
          onChange={(e) => setUnitPrice(e.target.value)}
        />
        <div className="valid-feedback">Looks good!</div>
      </div>

      <div className="col-md-4">
        <label for="validationCustom02" className="form-label">
          Unit In Stock
        </label>
        <input
          aria-label={UnitInStock}
          type="text"
          className="form-control"
          id="validationCustom02"
          onChange={(e) => setUnitInStock(e.target.value)}
        />
        <button className="btn btn-primary" onClick={handleUpdateChanges}>
          Submit form
        </button>
      </div>
    </div>
  );
};
