import React, {useEffect} from 'react';
import { 
  BrowserRouter as Router,
  Routes,
  Route
} from 'react-router-dom';
import Main from './pages/Main';
import Result from './pages/Result';
import NotFound from './pages/NotFound';

import axios from 'axios';

function App() {

  useEffect(() => {
    axios.get('/api/test')
      .then(res => console.log(res))
      .catch()
  })

  return (
    <div className='App'>
      <Router>
        <Routes>
          <Route path="/" element={<Main />}></Route>
          <Route path="/result" element={<Result />}></Route>
          <Route path='*' element={<NotFound />}></Route>
        </Routes>
      </Router>
    </div>
  );
}

export default App;
