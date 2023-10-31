export const PostImagesModal = ({Post}) => {
    return <>
    <div className="max-h-screen overflow-y-scroll">
    {Post?.images?.split(",").map(image => <a href={image} target="_blank"><img className="mb-5" src={image}/></a>)}
    </div>
    </>
}