import axios from "axios";

export const getProductsAsync = async () => {
  let urlFromServer = "http://localhost:7275/api/Products";
  let ProductsFromServer = await axios.get(urlFromServer);
  return ProductsFromServer.data;
};

export const addUserCommentAsync = async (userComment) => {
  console.log(userComment);

  await axios.post(
    "http://localhost:7275/api/Products/allProducts",
    userComment
  );
};

export const deleteProductAsync = async (productID) => {
  console.log(`productID : ${productID}`);
  const res = await axios.delete(
    `http://localhost:7275/api/Products/deleteProduct/${productID}`
  );
  console.log(res);
};

export const UpdateProductAsync = async (updateProduct) => {
  console.log(`updateProduct : ${updateProduct.ProductID}`);
  const res = await axios.put(
    `http://localhost:7275/api/Products/UpdateProduct/${updateProduct.ProductID}`,
    updateProduct
  );
  console.log(res);
};
