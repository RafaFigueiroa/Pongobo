import { useEffect, useState } from 'react';

function App() {
  const[leaderboard, setLeaderboard] = useState([]);
  const token = '2edde06949126192abe198b8224c3d1fb463b424';
  const apiUrl = 'https://api.lootlocker.io/game/leaderboards/20904/list?count=10';

  useEffect(() =>{
    const getData = async (url) => {
      try{
        const res = await fetch(url, {
          method: 'GET',
          headers: {
            'Content-type': 'application/json',
            'x-session-token': token,
          }
        });
        const data = await res.json();
        
        setLeaderboard(data.items);
        console.log(leaderboard);
      }
      catch(e){
        console.log("erro acessando API: ", e);
      }
    }

    getData(apiUrl);
  }, []);

  return (
    <div>
      <h1 className='text-white font-bold text-4xl py-6 px-10 bg-indigo-800'>PONGOBÓ</h1>
      <div className='text-center'>
        <h2 className='text-indigo-800 text-3xl p-10 font-semibold'>Tabela de Classificação</h2>
        <div className='flex justify-center'>
          <table className='text-xl border-collapse bg-indigo-200 border-indigo-800 border-2 *:border-white *:border text-center'>
            <thead>
              <tr className='text-white bg-indigo-800'>
                <th className='pl-5'>Posição</th>
                <th className='px-10'>Nome</th>
                <th className='pr-5'>Score</th>
              </tr>
            </thead>
            <tbody>
              {leaderboard.map((item) => (
                <tr key={item.id} className='table-auto'>
                  <td><b>{item.rank}</b>.</td>
                  <td>{item.member_id}</td>
                  <td>{item.score}</td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </div>
    </div>
  )
}

export default App;
