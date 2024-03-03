
import { fireEvent, render, screen,getByRole } from "@testing-library/react";
import "@testing-library/jest-dom";
import { BrowserRouter, useLocation } from "react-router-dom";
import CreateUpdateMovie from "../Component/CreateUpdateMovie";

import axios from "axios";
describe(" Render CreateUpdate Component  ", () => {
  it("check exist of View button", async () => {
    const { getByRole } = render(
      <BrowserRouter>
      <CreateUpdateMovie/>
      </BrowserRouter>
    );
    const button=getByRole('link', { id: "ViewButton" })
    expect(button).toBeInTheDocument();
  });
});
describe("Render CreateUpdate Component ", () => {
    it("Check click event of view button", async () => {
      const { getByRole } = render(
      <BrowserRouter>
      <CreateUpdateMovie/>
      </BrowserRouter>
      );
  
      const button=getByRole('link', { id: "ViewButton" })
      
      fireEvent.click(button);
      
  
    });
  });
  test('shows error messages if fields is empty', () => {
    // render the component
    const { getByText ,getByTestId} = render(<BrowserRouter>
    <CreateUpdateMovie/>
    </BrowserRouter>);
    // get the elements
    
    const AddMovie = getByTestId('AddMovie');
    // click the login button

    fireEvent.click(AddMovie);
    // check if the error messages are shown
    expect(getByTestId('nameerror')).toHaveTextContent('**Required ! Must fill the field **');
    expect(getByTestId('typeerror')).toHaveTextContent('**Required ! Must fill the field **');
    expect(getByTestId('langerror')).toHaveTextContent('**Required ! Must fill the field **');
    expect(getByTestId('duraerror')).toHaveTextContent('**Required ! Must fill the field **');
  });
  

  