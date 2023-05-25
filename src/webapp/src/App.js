import React from 'react';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import AboutPage from './pages/AboutPage';
import IndexPage from './pages/IndexPage';
import './style/App.css'
import LobbyPage from './pages/LobbyPage';

function App() {
    return (
        <BrowserRouter>
            <Routes>
                <Route path="/about" element={<AboutPage/>}></Route>
                <Route path="/" element={<IndexPage/>}></Route>
                <Route path="/lobby" element={<LobbyPage/>}></Route>
            </Routes>
        </BrowserRouter>
    );
}

export default App;
