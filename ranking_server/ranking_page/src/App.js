import { 
  BrowserRouter as Router,
  Routes,
  Route
} from 'react-router-dom';
import Main from './pages/Main';
import Result from './pages/Result';
import NotFound from './pages/NotFound';

function App() {
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
