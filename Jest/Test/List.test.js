
import { fireEvent, render, screen } from "@testing-library/react";
import "@testing-library/jest-dom";
import { BrowserRouter } from "react-router-dom";
import axios from "axios";

import { ReactDOM } from "react-dom";
import ListMovie from '../Component/ListMovie';


describe("Check exist of Add Movie button ", () => {
  it("Renders the List component", async () => {
    const { getByRole } = render(
    <BrowserRouter>
    <ListMovie/>
    </BrowserRouter>
    );

    const button=getByRole('link', { name: "Add Movie" })
    
    expect(button).toBeInTheDocument();
  });
});

describe("Check Redirection to CreateUpdateComponent after clicking the add movie button ", () => {
  it("Renders the List component", async () => {
    const { getByRole } = render(<BrowserRouter>
        <ListMovie/>
        </BrowserRouter>);

    const button=getByRole('link', { name: "Add Movie" })
    
    fireEvent.click(button);
    const title = global.window.location.href;
    expect(title).toBe("http://localhost/create");
  });
});
describe("Check exist of Table column movie name ", () => {
    it("Renders the List component", async () => {
      const { getByText } = render(
      <BrowserRouter>
      <ListMovie/>
      </BrowserRouter>
      );
  
      const MovieNameTitle=getByText("Movie Name" )
      
      expect(MovieNameTitle).toBeInTheDocument();
    });
  });
  
  describe("Check exist of Table column movie language ", () => {
    it("Renders the List component", async () => {
      const { getByText } = render(
      <BrowserRouter>
      <ListMovie/>
      </BrowserRouter>
      );
  
      const MovieLanguageTitle=getByText("Movie Language" )
      
      expect(MovieLanguageTitle).toBeInTheDocument();
    });
  });
  describe("Check exist of Table column movie type ", () => {
    it("Renders the List component", async () => {
      const { getByText } = render(
      <BrowserRouter>
      <ListMovie/>
      </BrowserRouter>
      );
  
      const MovieTypeTitle=getByText("Movie Type" )
      
      expect(MovieTypeTitle).toBeInTheDocument();
    });
  });
  describe("Check exist of Table column durations ", () => {
    it("Renders the List component", async () => {
      const { getByText } = render(
      <BrowserRouter>
      <ListMovie/>
      </BrowserRouter>
      );
  
      const MovieDurationsTitle=getByText("Movie Durations" )
      
      expect(MovieDurationsTitle).toBeInTheDocument();
    });
  });
  describe("Check exist of Table column action ", () => {
    it("Renders the List component", async () => {
      const { getByText } = render(
      <BrowserRouter>
      <ListMovie/>
      </BrowserRouter>
      );
  
      const Action=getByText("Action" )
      
      expect(Action).toBeInTheDocument();
    });
  });

  
 