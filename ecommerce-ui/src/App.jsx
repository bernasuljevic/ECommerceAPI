import { useEffect, useState } from "react";
import axios from "axios";
import "./App.css";

function App() {
  const [products, setProducts] = useState([]);

  useEffect(() => {
    axios
      .get("http://localhost:5137/Products")
      .then((response) => {
        setProducts(response.data);
      });
  }, []);

  return (
    <div className="dashboard">

      <div className="sidebar">
        <h2>E-Commerce</h2>

        <ul>
          <li>📦 Ürünler</li>
          <li>📂 Kategoriler</li>
          <li>🛒 Siparişler</li>
          <li>👥 Müşteriler</li>
        </ul>
      </div>

      <div className="content">

        <h1>Ürünler</h1>

        <div className="cards">

          <div className="card">
            <h3>Toplam Ürün</h3>
            <p>{products.length}</p>
          </div>

          <div className="card">
            <h3>Toplam Stok</h3>
            <p>
              {products.reduce((a, b) => a + b.stock, 0)}
            </p>
          </div>

        </div>

        <table className="product-table">

          <thead>
            <tr>
              <th>ID</th>
              <th>Ürün</th>
              <th>Fiyat</th>
              <th>Stok</th>
              <th>Kategori</th>
            </tr>
          </thead>

          <tbody>
            {products.map(product => (
              <tr key={product.id}>
                <td>{product.id}</td>
                <td>{product.name}</td>
                <td>{product.price} ₺</td>
                <td>{product.stock}</td>
                <td>{product.category}</td>
              </tr>
            ))}
          </tbody>

        </table>

      </div>

    </div>
  );
}

export default App;