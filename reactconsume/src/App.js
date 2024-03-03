import logo from './logo.svg';
import './App.css';
import axios from 'axios';
import { BrowserRouter,Routes, Route } from 'react-router-dom';
import LayoutComponent from './Component/LayoutComponent';
import HomeComponent from './Component/HomeComponent';
import CreateUpdateMovie from './Component/CreateUpdateMovie';
import ListMovie from './Component/ListMovie';
import LoginComponent from './Component/LoginComponent';
import RegisterComponent from './Component/RegisterComponent';
function App() {
  return (
    <div className="App">
      <LayoutComponent/>
     
      <BrowserRouter>
      <Routes>
        <Route path='/' element={<LoginComponent/>}></Route>
        <Route path='/register' element={<RegisterComponent/>}></Route>
        <Route path='/list' element={<ListMovie/>}></Route>
        <Route path='/create' element={<CreateUpdateMovie/>}></Route>
        <Route path='/create/:id' element={<CreateUpdateMovie/>}></Route>
        <Route path='/home' element={<HomeComponent/>}></Route>
      </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
