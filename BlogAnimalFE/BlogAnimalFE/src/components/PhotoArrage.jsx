export const PhotoArrage = ({ base64Image }) => {
  if (base64Image.length == 1) {
    return <img src={base64Image[0]} className="w-full" />;
  } else if (base64Image.length == 2) {
    return (
      <div className="flex">
        <img src={base64Image[0]} className="w-1/2" />
        <img src={base64Image[1]} className="w-1/2" />
      </div>
    );
  } else if (base64Image.length == 3) {
    return (
      <div className="flex items-center">
        <div className="w-1/2">
          <img src={base64Image[0]} className="w-full" />
        </div>
        <div className="w-1/2">
          <img src={base64Image[1]} className="w-auto h-1/2" />
          <img src={base64Image[2]} className="w-auto h-1/2" />
        </div>
      </div>
    );
  } else if (base64Image.length > 3) {
    const bgImage = "url("+ base64Image[2] +")";
    return (
      <div className="flex items-center">
        <div className="w-1/2">
          <img src={base64Image[0]} className="w-full" />
        </div>
        <div className="w-1/2">
          <img src={base64Image[1]} className="w-auto h-1/2" />
          <div className="w-auto h-1/2 text-center text-white bg-neutral-800 py-20">
            {/* <img src={base64Image[2]} className="w-auto h-1/2" /> */}
            +{base64Image.length-2}
          </div>
        </div>
      </div>
    );
  }
};
